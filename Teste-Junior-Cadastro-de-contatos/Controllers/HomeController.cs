using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teste_Junior_Cadastro_de_contatos.Models;
using Teste_Junior_Cadastro_de_contatos.Models.ViewModel;
using Teste_Junior_Cadastro_de_contatos.Services;

namespace Teste_Junior_Cadastro_de_contatos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactService _service;

        public HomeController( ContactService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.FindAllAsync();
            return View(list);
        }
        public IActionResult Create()
        {
            var viewmodel = new ContactViewModel();
            return View(viewmodel);           
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contatos contact)
        {
           
            if (!ModelState.IsValid)
            {
                var viewmodel = new ContactViewModel { Contact = contact};
                return View(viewmodel);
            }
            if(contact.Phone.Contains("-"))
            {
                string[] substring = contact.Phone.Split("-");
                contact.Phone = substring[0] + substring[1];
            }
           
            await _service.InsertAsync(contact);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
