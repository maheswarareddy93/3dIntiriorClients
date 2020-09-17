using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _3dIntiriorClients.ErrorHandling;
using _3dIntiriorClients.Helpers;
using _3dIntiriorClients.Interface;
using _3dIntiriorClients.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3dIntiriorClients.Controllers
{
    [TypeFilter(typeof(CustomErrorHandling))]
    public class GallaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGallaryData _gallaryData;
        public GallaryController(IGallaryData gallaryData, ApplicationDbContext context)
        {
            _gallaryData = gallaryData;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gallary()
        {
            GallaryViewModel model = new GallaryViewModel();
            model.SelectRoomType = _gallaryData.GetRoomTypes();           
            return View(model);
        }
        [HttpGet]        
        public IActionResult GallaryPartialView(string  id)
        {
            GallaryViewModel model = new GallaryViewModel();
            int Id = Convert.ToInt32(id);
            if (Id > 0)
            {
                GallaryImages img = _gallaryData.GetGallaryImages(Id);
                model.Gimages=img.Images;
                model.SelectRoomType = _gallaryData.GetRoomTypes();
                model.RoomType =(from g in model.SelectRoomType.Where(x => x.RoomId == Id) select g.RoomType).FirstOrDefault();
                model.RoomTypeID = Id;
                return PartialView("_GallaryView",model);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddImageToGallary()
        {
            GallaryViewModel model = new GallaryViewModel();
            model.SelectRoomType= _gallaryData.GetRoomTypes();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddImageToGallary(GallaryViewModel model)
        {
            if (CurrentAdminSession.User==null && CurrentAdminSession.UserID<0)
            {
                return RedirectToAction("Index","Admin");
            }
            if (ModelState.IsValid)
            {
                var data= _gallaryData.GetRoomTypes().Where(x=>x.RoomId==model.RoomTypeID).FirstOrDefault();
                model.RoomType = data.RoomType;
                _gallaryData.AddImagesToGallary(model);
                return RedirectToAction("Gallary", "Gallary");
            }
            return View(model);
        }
        public IActionResult RemoveImages()
        {
            if (CurrentAdminSession.User==null && CurrentAdminSession.UserID<0)
            {
                return RedirectToAction("Index","Admin");
            }
            GallaryViewModel model = new GallaryViewModel();
            model.SelectRoomType = _gallaryData.GetRoomTypes();
            return View(model);
        }
        public IActionResult RemoveImagePartial(string id)
        {
            GallaryViewModel model = new GallaryViewModel();
            int Id = Convert.ToInt32(id);
            if (Id > 0)
            {
                GallaryImages img = _gallaryData.GetGallaryImages(Id);
                model.Gimages = img.Images;
                model.SelectRoomType = _gallaryData.GetRoomTypes();
                model.RoomType = (from g in model.SelectRoomType.Where(x => x.RoomId == Id) select g.RoomType).FirstOrDefault();
                model.RoomTypeID = Id;
                return PartialView("RemoveImagePartialView", model);
            }
            return View();
        }
        //Removing the Image From the DataBase 
        public JsonResult RemoveImage(string[] id,string typeId)
        {

            string resultMsg = string.Empty;
            bool flag;
            if (id[0]!=null && !string.IsNullOrEmpty(typeId))
            {
                flag = _gallaryData.DeleteImagesFromGallary(id[0], typeId);
                if (flag)
                {
                    return Json("Images deleted Successfully.");
                }
            }
            else
            {
                resultMsg = "Please Select image to delete";
            }
            return Json("");
        }
    }
}
