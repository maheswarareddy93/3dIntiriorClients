using _3dIntiriorClients.Helpers;
using _3dIntiriorClients.Interface;
using _3dIntiriorClients.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3dIntiriorClients.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountData _account;
        

        public AccountController(IAccountData account)
        {
            _account = account;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserLogin()
        {
            if (CurrentUserSession.User != null && CurrentUserSession.UserID > 0)
            {
                return RedirectToAction("MyProjects", "Customer");
            }
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult UserLogin(LoginViewModel model)
        {
            if (CurrentUserSession.User != null && CurrentUserSession.UserID > 0)
            {
                return RedirectToAction("MyProjects", "Customer");
            }
            if (ModelState.IsValid)
            {
                CustomerInfo customer = _account.LoginCheck(model.email, model.password);
                if (customer != null)
                {
                    CurrentUser User = new CurrentUser();
                    User.UserID = customer.Customerid;
                    User.UserName = customer.Emailid;
                    User.Email = customer.Emailid;
                    User.Name = customer.Customername;
                    User.IsAdminRole = false;
                    CurrentUserSession.User = User;
                    HttpContext.Session.SetInt32("UserID", customer.Customerid);
                    return RedirectToAction("AddNewProject","Customer");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is wrong");
                }
            }
            return View();
        }
        public IActionResult Register()
        {
                RegisterViewModel model = new RegisterViewModel();
                return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = _account.AddUser(model);
                if (result)
                {
                    ModelState.AddModelError("", "Registered Successfully");
                }
                else
                {
                    ModelState.AddModelError("", "Plase check Details");
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserID");
            return RedirectToAction("UserLogin", "Account");
        }

    }
}
