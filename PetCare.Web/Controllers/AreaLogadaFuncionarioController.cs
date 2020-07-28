using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PetCare.Web.Controllers
{
    public class AreaLogadaFuncionarioController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
