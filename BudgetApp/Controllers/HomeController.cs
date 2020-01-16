using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BudgetApp.Models;
using Interfaces.Services;

namespace BudgetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService _login;
        private readonly ICredentialHoldingService _creds;

        public HomeController(ILogger<HomeController> logger, ILoginService login, ICredentialHoldingService creds)
        {
            _login = login;
            _logger = logger;
            _creds = creds;
        }

        public IActionResult Index()
        {

            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {

            if (_login.AuthenticateLogin(vm.Username, vm.Password))
            {
                return RedirectToAction("MainPage");
            }

            return RedirectToAction("Index");
        }

        public IActionResult MainPage()
        {
            if (!_creds.LoggedIn)
                return RedirectToAction("Index");

            return View();
        }

        public IActionResult Privacy()
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
