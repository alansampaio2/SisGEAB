using Microsoft.AspNetCore.Identity;
using SisGEAB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Contracts
{
    public interface IAccountManager
    {

        Task<bool> CheckPasswordAsync(Usuario user, string password);
        Task<(bool Succeeded, string[] Errors)> CreateRoleAsync(Funcao role, IEnumerable<string> claims);
        Task<(bool Succeeded, string[] Errors)> CreateUserAsync(Usuario user, IEnumerable<string> roles, string password);
        Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(Funcao role);
        Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(string roleName);
        Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(Usuario user);
        Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(string userId);
        Task<Funcao> GetRoleByIdAsync(string roleId);
        Task<Funcao> GetRoleByNameAsync(string roleName);
        Task<Funcao> GetRoleLoadRelatedAsync(string roleName);
        Task<List<Funcao>> GetRolesLoadRelatedAsync();
        Task<(Usuario User, string[] Roles)?> GetUserAndRolesAsync(string userId);
        Task<Usuario> GetUserByEmailAsync(string email);
        Task<Usuario> GetUserByIdAsync(string userId);
        Task<Usuario> GetUserByUserNameAsync(string userName);
        Task<IList<string>> GetUserRolesAsync(Usuario user);
        Task<List<(Usuario User, string[] Roles)>> GetUsersAndRolesAsync();
        Task<(bool Succeeded, string[] Errors)> ResetPasswordAsync(Usuario user, string newPassword);
        Task<bool> TestCanDeleteRoleAsync(string roleId);
        Task<bool> TestCanDeleteUserAsync(string userId);
        Task<(bool Succeeded, string[] Errors)> UpdatePasswordAsync(Usuario user, string currentPassword, string newPassword);
        Task<(bool Succeeded, string[] Errors)> UpdateRoleAsync(Funcao role, IEnumerable<string> claims);
        Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(Usuario user);
        Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(Usuario user, IEnumerable<string> roles);
        Task<string> GenerateEmailConfirmationTokenAsync(Usuario usuario);
        Task<(bool Succeeded, string[] Errors)> ConfirmEmailAsync(Usuario usuario, string token);
        Task<SignInResult> Login(string nomeUsuario, string senha, bool lembrarme);
    }
}
