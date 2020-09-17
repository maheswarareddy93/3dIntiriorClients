using _3dIntiriorClients.Interface;
using _3dIntiriorClients.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace _3dIntiriorClients.Repository
{
    public class CustomerRepositary : ICustomerData
    {
        static ApplicationDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public CustomerRepositary(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public List<PropertyTypes> GetPropertyTypes()
        {
            List<PropertyTypes> tblpropertytypes = new List<PropertyTypes>();
            tblpropertytypes = _context.PropertyTypes.ToList();
            return tblpropertytypes;
        }

        [Obsolete]
        public string ReferenceImagesToDB(Projectdatamodel model)
        {
            SaveImages(model);
            return null;
        }

        [Obsolete]
        public void SaveImages(Projectdatamodel model)
        {
            ReferenceImages ObjReferenceImages = new ReferenceImages();
            List<ReferenceImages> lstReferenceImages = new List<ReferenceImages>();
            RootImg ObjRootimg = new RootImg();
            ProjectDataInfo ObjTblprojectdata = new ProjectDataInfo();
            ProjectDataInfo info = new ProjectDataInfo();
            string cuuid = string.Empty;
            if (string.IsNullOrEmpty(model.CUUID)) { 
            using (var scope = new TransactionScope())
            {
                    cuuid = Guid.NewGuid().ToString("N").Substring(0, 5);
                    ObjTblprojectdata.CustomerId = model.CustomerId;
                    ObjTblprojectdata.cuuid = cuuid;
                    ObjTblprojectdata.Projectname = model.ProjectName;
                    ObjTblprojectdata.UnitType = model.Type;
                    ObjTblprojectdata.UnitSize = model.Unitsize;
                    _context.ProjectDataInfo.Add(ObjTblprojectdata);
                
                _context.SaveChanges();
                scope.Complete();
            }
            }
            if (model.count > 0)
            {
                int length = model.count;
                for (int i = 1; i <=length; i++)
                {
                    switch (i)
                    {
                        case 1:
                            ObjReferenceImages = CreateimgFolder(model.Room1, cuuid, model.Attachments1, model.comments1);
                            break;
                        case 2:
                            ObjReferenceImages = CreateimgFolder(model.Room2, cuuid, model.Attachments2, model.comments2);
                            break;
                        case 3:
                            ObjReferenceImages = CreateimgFolder(model.Room3, cuuid, model.Attachments3, model.comments3);
                            break;
                        case 4:
                            ObjReferenceImages = CreateimgFolder(model.Room4, cuuid, model.Attachments4, model.comments4);
                            break;
                        case 5:
                            ObjReferenceImages = CreateimgFolder(model.Room5, cuuid, model.Attachments5, model.comments5);
                            break;
                        case 6:
                            ObjReferenceImages = CreateimgFolder(model.Room6, cuuid, model.Attachments6, model.comments6);
                            break;
                        case 7:
                            ObjReferenceImages = CreateimgFolder(model.Room7, cuuid, model.Attachments7, model.comments7);
                            break;
                        case 8:
                            ObjReferenceImages = CreateimgFolder(model.Room8, cuuid, model.Attachments8, model.comments8);
                            break;
                        case 9:
                            ObjReferenceImages = CreateimgFolder(model.Room9, cuuid, model.Attachments9, model.comments9);
                            break;
                        case 10:
                            ObjReferenceImages = CreateimgFolder(model.Room10, cuuid, model.Attachments10, model.comments10);
                            break;
                        case 11:
                            ObjReferenceImages = CreateimgFolder(model.Room11, cuuid, model.Attachments11, model.comments11);
                            break;
                        case 12:
                            ObjReferenceImages = CreateimgFolder(model.Room12, cuuid, model.Attachments12, model.comments12);
                            break;
                        case 13:
                            ObjReferenceImages = CreateimgFolder(model.Room13, cuuid, model.Attachments13, model.comments13);
                            break;
                        case 14:
                            ObjReferenceImages = CreateimgFolder(model.Room14, cuuid, model.Attachments14, model.comments14);
                            break;
                    }
                    lstReferenceImages.Add(ObjReferenceImages);
                    
                }
               
                info = _context.ProjectDataInfo.Where(x => x.cuuid == cuuid && x.CustomerId == model.CustomerId).FirstOrDefault();
                if (!string.IsNullOrEmpty(info.Referenceimages))
                {
                    lstReferenceImages = JsonSerializer.Deserialize<List<ReferenceImages>>(info.Referenceimages);
                    ObjRootimg.list = lstReferenceImages;
                }
                else
                {
                    ObjRootimg.list = lstReferenceImages;                    
                }
                info.Referenceimages = JsonSerializer.Serialize(ObjRootimg.list);
                info.Referenceimages = ObjTblprojectdata.Referenceimages;
                info.CreatedDate=DateTime.Now.ToString("dd-MM-yyyy");
                _context.SaveChanges();
            }
        }
        [Obsolete]
        public ReferenceImages CreateimgFolder(string roomName, string id, IEnumerable<IFormFile> images, string comments)
        {
            RootImg objRootImg = new RootImg();
            string folderName = string.Empty;
            List<ReferenceImages> lstReferenceImages = new List<ReferenceImages>();
            ReferenceImages ObjReferenceImages = new ReferenceImages();
            List<Images> lstImages = new List<Images>();
            string webRootPath = _hostingEnvironment.WebRootPath;
            if (images != null)
            {
                folderName = "ApplicationDocuments\\" + folderName + "\\" + id + "\\";
                string basePath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(basePath))
                    System.IO.Directory.CreateDirectory(basePath);
                foreach (IFormFile attachment in images)
                {
                    Images ObjImages = new Images();
                    ObjImages.Id = Guid.NewGuid().ToString("N").Substring(0, 5);
                    string GUID = Guid.NewGuid().ToString();
                    string fileName = attachment.FileName;
                    string fileExtension = Path.GetExtension(fileName);
                    fileName = GUID + fileExtension;
                    ObjImages.Name = fileName;
                    string destinationPath = Path.Combine(basePath, fileName);
                    var stream = new FileStream(destinationPath, FileMode.Create);
                    attachment.CopyToAsync(stream);
                    lstImages.Add(ObjImages);
                }
                ObjReferenceImages.RoomType = roomName;
                ObjReferenceImages.Id = Guid.NewGuid().ToString("N").Substring(0, 5);
                ObjReferenceImages.Comments = comments;
                ObjReferenceImages.CreatedDate = DateTime.Now.ToString("dd-mm-yyyy");
                ObjReferenceImages.ReferenceImg = lstImages;
            }
            return ObjReferenceImages;
        }

        public List<ProjectDataInfo> GetProjectList(int id)
        {
            List<ProjectDataInfo> lstInfo = new List<ProjectDataInfo>();
            lstInfo = _context.ProjectDataInfo.Where(x => x.CustomerId == id).ToList();
            lstInfo = lstInfo.OrderByDescending(x => x.CreatedDate).ToList();
            return lstInfo;
        }

        public ThreeDInfoViewModel Get3DViewInfo(string id)
        {
            ThreeDInfoViewModel objThreeDViewInfo = new ThreeDInfoViewModel();
            var data = _context.ProjectDataInfo.Where(x => x.cuuid == id).FirstOrDefault();
            ThreeDViewInfo  objThreeDViewIn = JsonSerializer.Deserialize<ThreeDViewInfo>(data.FinalViewImages);
            objThreeDViewInfo.Cid = data.cuuid;
            objThreeDViewInfo.Link = data.ThreeDLink;
            objThreeDViewInfo.Specs = objThreeDViewIn.Specs;
            objThreeDViewInfo.Dimensions = objThreeDViewIn.Dimensions;
            return objThreeDViewInfo;
        }
    }
}

