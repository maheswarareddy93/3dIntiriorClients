using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3dIntiriorClients.Helpers;
using _3dIntiriorClients.Interface;
using _3dIntiriorClients.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3dIntiriorClients.Controllers
{

    public class AdminController : Controller
    {
        private readonly IAccountData _account;
        private readonly IAdminData _admin;
        public AdminController(IAccountData account, IAdminData admin)
        {
            _account = account;
            _admin = admin;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (CurrentAdminSession.User != null && CurrentAdminSession.UserID > 0)
            {
                return RedirectToAction("NewCustomers", "Admin");
            }
            if (ModelState.IsValid)
            {
                AdminsInfo admin = _account.AdminLoginCheck(model.email, model.password);
                if (admin != null)
                {
                    CurrentAdminUser User = new CurrentAdminUser();
                    User.UserID = admin.Id;
                    User.UserName = admin.Email;
                    User.Email = admin.Email;
                    User.Name = admin.Name;
                    User.IsAdminRole = true;
                    CurrentAdminSession.User = User;
                    HttpContext.Session.SetInt32("UserID", admin.Id);
                    return RedirectToAction("NewCustomers", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is wrong");
                }
            }
            return View();
        }

        public IActionResult Customers()
        {
            if (CurrentAdminSession.User == null && CurrentAdminSession.UserID < 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<CustomerViewModel> lst = _admin.GetCustomers();
            return View(lst);
        }
        public IActionResult NewCustomers()
        {
            if (CurrentAdminSession.User == null && CurrentAdminSession.UserID < 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<CustomerViewModel> lst = _admin.GetCustomers();
            return View(lst);
        }
        public IActionResult ReferenceImgView(string pid)
        {
            ProjectDataInfo info = new ProjectDataInfo();
            if (CurrentAdminSession.User == null && CurrentAdminSession.UserID < 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (!string.IsNullOrEmpty(pid))
            {
                info = _admin.GetCustomerData(null, pid);
            }
            return View(info);
        }
        public IActionResult Gallary()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ThreeDSpecUpdate(string id)
        {
            ThreeDSpecUpdate model = new ThreeDSpecUpdate();
            model.CUUID = id;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThreeDSpecUpdate(ThreeDSpecUpdate model)
        {
            _admin.UpdateThreeDInfo(model);
            return View(model);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserID");
            return RedirectToAction("Index","Admin");
        }
    }
}
