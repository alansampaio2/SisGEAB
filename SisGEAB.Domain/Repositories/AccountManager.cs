using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SisGEAB.Domain.Contracts;
using SisGEAB.Domain.Core;
using SisGEAB.Domain.Data;
using SisGEAB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Repositories
{
    public class AccountManager : IAccountManager
    {
        private readonly Contexto _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Funcao> _roleManager;


        public AccountManager(
            Contexto context,
            UserManager<Usuario> userManager,
            RoleManager<Funcao> roleManager,
            IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _context.CurrentUserId = httpAccessor.HttpContext?.User.FindFirst(ClaimConstants.Subject)?.Value?.Trim();
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task<bool> CheckPasswordAsync(Usuario user, string password)
        {
            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                if (!_userManager.SupportsUserLockout)
                    await _userManager.AccessFailedAsync(user);

                return false;
            }

            return true;
        }

        public async Task<(bool Succeeded, string[] Errors)> ConfirmEmailAsync(Usuario usuario, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(usuario, token);
            if(!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, new string[] { });
        }

        public async Task<(bool Succeeded, string[] Errors)> CreateRoleAsync(Funcao role, IEnumerable<string> claims)
        {
            if (claims == null)
                claims = new string[] { };

            string[] invalidClaims = claims.Where(c => Permissoes.SelecionarPermissaoPorValor(c) == null).ToArray();
            if (invalidClaims.Any())
                return (false, new[] { "Os seguintes tipos de Claims são inválidos: " + string.Join(", ", invalidClaims) });


            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            role = await _roleManager.FindByNameAsync(role.Name);

            foreach (string claim in claims.Distinct())
            {
                result = await this._roleManager.AddClaimAsync(role, new Claim(ClaimConstants.Permission, Permissoes.SelecionarPermissaoPorValor(claim)));

                if (!result.Succeeded)
                {
                    await DeleteRoleAsync(role);
                    return (false, result.Errors.Select(e => e.Description).ToArray());
                }
            }

            return (true, new string[] { });
        }

        public async Task<(bool Succeeded, string[] Errors)> CreateUserAsync(Usuario user, IEnumerable<string> roles, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            user = await _userManager.FindByNameAsync(user.UserName);

            try
            {
                result = await this._userManager.AddToRolesAsync(user, roles.Distinct());
            }
            catch
            {
                await DeleteUserAsync(user);
                throw;
            }

            if (!result.Succeeded)
            {
                await DeleteUserAsync(user);
                return (false, result.Errors.Select(e => e.Description).ToArray());
            }

            return (true, new string[] { });
        }

        public Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(Funcao role)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(Usuario user)
        {
            var result = await _userManager.DeleteAsync(user);
            return (result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
                return await DeleteUserAsync(user);

            return (true, new string[] { });
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(Usuario usuario)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(usuario);
        }

        public async Task<Funcao> GetRoleByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }

        public async Task<Funcao> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<Funcao> GetRoleLoadRelatedAsync(string roleName)
        {
            var role = await _context.Roles
                .Include(r => r.Claims)
                .Include(r => r.Usuarios)
                .Where(r => r.Name == roleName)
                .SingleOrDefaultAsync();

            return role;
        }

        public async Task<List<Funcao>> GetRolesLoadRelatedAsync()
        {
            IQueryable<Funcao> rolesQuery = _context.Roles
                .Include(r => r.Claims)
                .Include(r => r.Usuarios)
                .OrderBy(r => r.Name);
                   
            var roles = await rolesQuery.ToListAsync();

            return roles;
        }

        public async Task<(Usuario User, string[] Roles)?> GetUserAndRolesAsync(string userId)
        {
            var user = await _context.Users
                .Include(u => u.Roles)
                .Where(u => u.Id == userId)
                .SingleOrDefaultAsync();

            if (user == null)
                return null;

            var userRoleIds = user.Roles.Select(r => r.RoleId).ToList();

            var roles = await _context.Roles
                .Where(r => userRoleIds.Contains(r.Id))
                .Select(r => r.Name)
                .ToArrayAsync();

            return (user, roles);
        }

        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<Usuario> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<Usuario> GetUserByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IList<string>> GetUserRolesAsync(Usuario user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<List<(Usuario User, string[] Roles)>> GetUsersAndRolesAsync()
        {
            IQueryable<Usuario> usersQuery = _context.Users
                .Include(u => u.Roles)
                .OrderBy(u => u.UserName);

            var users = await usersQuery.ToListAsync();

            var userRoleIds = users.SelectMany(u => u.Roles.Select(r => r.RoleId)).ToList();

            var roles = await _context.Roles
                .Where(r => userRoleIds.Contains(r.Id))
                .ToArrayAsync();

            return users
                .Select(u => (u, roles.Where(r => u.Roles.Select(ur => ur.RoleId).Contains(r.Id)).Select(r => r.Name).ToArray()))
                .ToList();
        }

        public async Task<(bool Succeeded, string[] Errors)> ResetPasswordAsync(Usuario user, string newPassword)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, new string[] { });
        }

        public Task<bool> TestCanDeleteRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TestCanDeleteUserAsync(string userId)
        {
            //if (await _context.Orders.Where(o => o.CashierId == userId).AnyAsync())
            //    return false;

            //canDelete = !await ; //Do other tests...

            return true;
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdatePasswordAsync(Usuario user, string currentPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, new string[] { });
        }

        public Task<(bool Succeeded, string[] Errors)> UpdateRoleAsync(Funcao role, IEnumerable<string> claims)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(Usuario user)
        {
            return await UpdateUserAsync(user, null);
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(Usuario user, IEnumerable<string> roles)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            if (roles != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var rolesToRemove = userRoles.Except(roles).ToArray();
                var rolesToAdd = roles.Except(userRoles).Distinct().ToArray();

                if (rolesToRemove.Any())
                {
                    result = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                    if (!result.Succeeded)
                        return (false, result.Errors.Select(e => e.Description).ToArray());
                }

                if (rolesToAdd.Any())
                {
                    result = await _userManager.AddToRolesAsync(user, rolesToAdd);
                    if (!result.Succeeded)
                        return (false, result.Errors.Select(e => e.Description).ToArray());
                }
            }

            return (true, new string[] { });
        }
    }
}
