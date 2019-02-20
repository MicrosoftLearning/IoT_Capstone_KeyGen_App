using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IoT.Capstone.KeyGen.Admin.Models;
using Newtonsoft.Json;

namespace IoT.Capstone.KeyGen.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly KeyGenContext _keyGenContext;

        public HomeController(KeyGenContext keyGenContext)
        {
            _keyGenContext = keyGenContext;
        }

        public IActionResult Index()
        {
            var users = _keyGenContext.EdxUsers.OrderBy(u => u.EdxId).ToList();
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public FileContentResult GenerateCsv()
        {
            var users = _keyGenContext.EdxUsers.OrderBy(u => u.EdxId).ToList();
            var sb = new StringBuilder();
            sb.AppendLine("EdxId, Uid");
            foreach (var edxUser in users)
            {
                sb.AppendLine($"{edxUser.EdxId},{edxUser.Uid:X4}");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "EdxUserList.csv");
        }
    }
}
