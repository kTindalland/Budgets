using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BudgetApp.Models;
using Interfaces.Services;
using Database;

namespace BudgetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService _login;
        private readonly ICredentialHoldingService _creds;
        private readonly BudgetContext _context;

        public HomeController(ILogger<HomeController> logger, ILoginService login, ICredentialHoldingService creds, BudgetContext context)
        {
            _login = login;
            _logger = logger;
            _creds = creds;
            _context = context;
        }

        public IActionResult Index()
        {

            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {

            string errormsg;
            if (_login.AuthenticateLogin(vm.Username, vm.Password, out errormsg))
            {
                return RedirectToAction("MainPage");
            }

            vm.ErrorMessage = errormsg;

            return View("Index", vm);
        }

        public IActionResult MainPage(int options = 0)
        {
            // Define options
            var allBudgets = 1;

            if (!_creds.LoggedIn)
                return RedirectToAction("Index");

            var vm = new MainPageViewModel();

            var userId = _context.Users.First(r => r.Username == _creds.Username).Id;

            if ((options & allBudgets) == 1)
            {
                vm.ActiveBudgets = _context.Budgets.ToList();
            }
            else
            {
                vm.ActiveBudgets = _context.Budgets.Where(r => r.UserId == userId && r.Active).ToList();
            }

            vm.RecentIncomeRecords = _context.IncomeRecords.Where(r => r.UserId == userId).ToList();

            return View(vm);
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
