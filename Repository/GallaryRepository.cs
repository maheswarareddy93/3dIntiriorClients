using _3dIntiriorClients.Interface;
using _3dIntiriorClients.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace _3dIntiriorClients.Repository
{
    
    public class GallaryRepository : IGallaryData
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        [Obsolete]
        public GallaryRepository(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        //Here Adding Images to DB By RoomType
        [Obsolete]
        public bool AddImagesToGallary(GallaryViewModel model)
        {
           
            GallaryImages images = new GallaryImages();
            List<GallaryImage> lstImagesData = new List<GallaryImage>();
            GallaryImagesToDB imgG = new GallaryImagesToDB();
            if (model!=null)
            {
                 images = _context.GallaryImages.Where(x => x.RoomTypeID == model.RoomTypeID).FirstOrDefault();
                if (images!=null)
                {
                    lstImagesData = CreateImageInGallary(model.lstImages, model.RoomType);
                    if (images.Images!=null)
                    {
                        imgG = JsonSerializer.Deserialize<GallaryImagesToDB>(images.Images);
                        imgG.lstImages.AddRange(lstImagesData);
                        images.UpdatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                        images.Images = JsonSerializer.Serialize(imgG);
                    }
                    else
                    {

                    }
                }
                else
                {
                    GallaryImages images1 = new GallaryImages();
                    images1.RoomTypeID = model.RoomTypeID;
                    images1.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    images1.UpdatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    lstImagesData = CreateImageInGallary(model.lstImages,model.RoomType);
                    imgG.Id = model.RoomTypeID;
                    imgG.RoomType =model.RoomType;
                    imgG.lstImages = lstImagesData;
                    images1.Images = JsonSerializer.Serialize(imgG);
                    _context.GallaryImages.Add(images1);
                }
                _context.SaveChanges();
            }
            return false;
        }

        //Here Creating Folder Of type Room and Adding Images to Folder
        [Obsolete]
        public List<GallaryImage> CreateImageInGallary(IEnumerable<IFormFile> files,string roomType)
        {
            string folderName =string.Empty;
            string webRootPath = _hostingEnvironment.WebRootPath;
            List<GallaryImage> lstImages = new List<GallaryImage>();
            folderName = "ApplicationDocuments\\GallaryImages\\" +roomType + "\\";
            string basePath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(basePath))
                System.IO.Directory.CreateDirectory(basePath);
            foreach (IFormFile image  in files )
            {
                GallaryImage imageDetails = new GallaryImage();
                string GUID = Guid.NewGuid().ToString();
                string fileName = image.FileName;
                string fileExtension = Path.GetExtension(fileName);
                fileName = GUID + fileExtension;
                imageDetails.Id= Guid.NewGuid().ToString("N").Substring(0, 5);
                imageDetails.FileName = fileName;
                string destinationPath = Path.Combine(basePath, fileName);
                var stream = new FileStream(destinationPath, FileMode.Create);
                image.CopyToAsync(stream);
                imageDetails.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                imageDetails.UpdatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                lstImages.Add(imageDetails);
            }
            return lstImages;
        }

        [Obsolete]
        public bool DeleteImagesFromGallary(string imageId, string roomType)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
           GallaryImagesToDB lstImg = new GallaryImagesToDB();
            var room = GetRoomTypes().Where(x => x.RoomId == Convert.ToInt32(roomType)).FirstOrDefault();
            string RoomName = room.RoomType;
            string folderName = "ApplicationDocuments\\GallaryImages\\" + RoomName + "\\";
            GallaryImagesToDB imgs = new GallaryImagesToDB();
            var images= _context.GallaryImages.Where(x=>x.RoomTypeID==Convert.ToInt32(roomType)).FirstOrDefault();
            if (images!=null)
            {
                if (images.Images!=null)
                {
                    imgs = JsonSerializer.Deserialize<GallaryImagesToDB>(images.Images);
                    string[] arr = imageId.Split(',');
                    foreach (string id in arr)
                    {
                        GallaryImage imgsToRemove = imgs.lstImages.Where(x=>x.Id==id).FirstOrDefault();
                        if (imgsToRemove!=null) { 
                        string basePath = Path.Combine(webRootPath, folderName);
                        string filePath = basePath + "\\" + imgsToRemove.FileName;
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                        imgs.lstImages.Remove(imgsToRemove);
                        }
                    }
                     images.Images= JsonSerializer.Serialize(imgs);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public GallaryImages GetGallaryImages(int id)
        {
            return _context.GallaryImages.Where(x=>x.RoomTypeID==id).FirstOrDefault();
        }

        public List<RoomTypes> GetRoomTypes()
        {
            return new List<RoomTypes>( _context.RoomTypes.ToList());
        }
    }
}
