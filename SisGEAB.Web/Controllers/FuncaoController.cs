using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisGEAB.Web.Controllers
{
    public class FuncaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
