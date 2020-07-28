using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Service.Abstraction;
using PetCare.Repository.Abstraction;

namespace PetCare.Web.Controllers
{
    public class CadastroClienteController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
