using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IoT.Capstone.KeyGen.Client.Models;
using IoT.Capstone.KeyGen.Client.Services;

namespace IoT.Capstone.KeyGen.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly EdxUserService _edxUserService;
        public HomeController(EdxUserService edxUserService)
        {
            _edxUserService = edxUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var user = await _edxUserService.GetUserAsync(model.EdxId);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
