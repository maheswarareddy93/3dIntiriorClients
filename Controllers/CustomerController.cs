using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3dIntiriorClients.Helpers;
using _3dIntiriorClients.Interface;
using _3dIntiriorClients.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _3dIntiriorClients.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerData _customer;
        private readonly IAdminData _admin;

        public CustomerController(ICustomerData customer, IAdminData admin)
        {
            _customer = customer;
            _admin = admin;
        }
        public IActionResult MyProjects()
        {
            if (CurrentUserSession.User == null && CurrentUserSession.UserID < 0)
            {
                return RedirectToAction("UserLogin", "Account");
            }
            else
            {
                List<ProjectDataInfo> lstdata = _customer.GetProjectList(CurrentUserSession.UserID);
                return View(lstdata);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MyProjects(Projectdatamodel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    var selectUnit = _customer.GetPropertyTypes().Find(p => p.Id == model.Id);
                    if (selectUnit != null)
                    {   
                        model.Type = selectUnit.Type.ToString();
                    }
                    if (model.count >= 0)
                    {
                        _customer.ReferenceImagesToDB(model);
                    }
                   return   RedirectToAction("ProjectDetails","Customer");
                }
                model.SelectUnitType = _customer.GetPropertyTypes();
            }
            return View(model);
        }
        public IActionResult ProjectDetails(string pid)
        {
            ProjectDataInfo info = new ProjectDataInfo();
            if (CurrentUserSession.User == null && CurrentUserSession.UserID < 0)
            {
                return RedirectToAction("UserLogin", "Account");
            }
            if (!string.IsNullOrEmpty(pid))
            {
                info = _admin.GetCustomerData(null, pid);
            }
            return View(info);
        }
        public IActionResult AddNewProject()
        {
            if (CurrentUserSession.User == null && CurrentUserSession.UserID < 0)
            {
                return RedirectToAction("UserLogin", "Account");
            }
            else
            {
                Projectdatamodel model = new Projectdatamodel();
                model.CustomerId = Convert.ToInt32(CurrentUserSession.UserID);
                model.SelectUnitType = _customer.GetPropertyTypes();
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewProject(Projectdatamodel model)
        {
            if (CurrentUserSession.User == null && CurrentUserSession.UserID < 0)
            {
                return RedirectToAction("UserLogin", "Account");
            }
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    var selectUnit = _customer.GetPropertyTypes().Find(p => p.Id == model.Id);
                    if (selectUnit != null)
                    {
                        model.Type = selectUnit.Type.ToString();
                    }
                    if (model.count >= 0)
                    {
                        _customer.ReferenceImagesToDB(model);
                    }
                    return RedirectToAction("ProjectDetails", "Customer");
                }
                model.SelectUnitType = _customer.GetPropertyTypes();
            }
            return View(model);
        }
        public IActionResult ThreeDView(string id)
        {
            if (CurrentUserSession.User == null && CurrentUserSession.UserID < 0)
            {
                return RedirectToAction("UserLogin", "Account");
            }
            if (!string.IsNullOrEmpty(id)) {
                ThreeDInfoViewModel obj = _customer.Get3DViewInfo(id);
                return View(obj);
            }
            return RedirectToAction("Myprojects","Customer"); ;
        }
        public IActionResult CompletedProjects()
        {
            int CustomerID = 0;
            if (CurrentUserSession.User == null && CurrentUserSession.UserID < 0)
            {
                return RedirectToAction("UserLogin", "Account");
            }
            else
            {
                CustomerID = CurrentUserSession.UserID;
                    }
            List<CustomerViewModel> lstCustomers  = _admin.GetCustomers();
            lstCustomers = lstCustomers.Where(x => x.CustomerId == CustomerID && x.FinalViewImages!=null).ToList();
            return View(lstCustomers);
        }
        
    }
}
