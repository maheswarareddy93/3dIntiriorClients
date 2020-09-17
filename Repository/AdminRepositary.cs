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

namespace _3dIntiriorClients.Repository
{
    public class AdminRepositary : IAdminData
    {
        static ApplicationDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public AdminRepositary(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        //Getting the Customer Data By CustomerId and Unique Id 
        public ProjectDataInfo GetCustomerData(string cid, string cuuid)
        {
            ProjectDataInfo pdinfo = _context.ProjectDataInfo.Where(x => x.cuuid == cuuid).FirstOrDefault();
            return pdinfo;
        }
        //Getting the List Of Customers 
        public List<CustomerViewModel> GetCustomers()
        {
            var ObjCustomerViewModel = (from pd in _context.ProjectDataInfo
                                        join od in _context.customerInfo on pd.CustomerId equals od.Customerid
                                        orderby od.Customerid
                                        select new CustomerViewModel
                                        {
                                            CustomerId = od.Customerid,
                                            CustomerName = od.Customername,
                                            CreatedDate = pd.CreatedDate,
                                            Projectname = pd.Projectname,
                                            UnitType = pd.UnitType,
                                            UnitSize = pd.UnitSize,
                                            cuuid = pd.cuuid,
                                            Referenceimages = pd.Referenceimages,
                                            FinalViewImages = pd.FinalViewImages,
                                        }).ToList(); 
            return ObjCustomerViewModel;
        }


        //Adding the 3d Specifications to DataBase and Create File Name
        [Obsolete]
        public  void UpdateThreeDInfo(ThreeDSpecUpdate specifications)
        {
            ThreeDViewInfo info = new ThreeDViewInfo();
            ProjectDataInfo Info = _context.ProjectDataInfo.Where(x => x.cuuid == specifications.CUUID).FirstOrDefault();
            if (Info!=null)
            {
                List<SpecificationsInfo> lstSpec = new List<SpecificationsInfo>();
                List<ThreeDImageDimensitionsInfo> lstDimensions = new List<ThreeDImageDimensitionsInfo>();
                List<Images> lstImages = new List<Images>();
                foreach (var specs in specifications.Specification)
                {
                    SpecificationsInfo spe = new SpecificationsInfo();
                    spe.ElementName = specs.ElementName;
                    spe.Brand = specs.Brand;
                    spe.ProductLink = specs.ProductLink;
                    lstImages = CreateFile(specs.Files, specifications.CUUID);
                    spe.images = lstImages;
                    lstSpec.Add(spe);
                }
                foreach (var dimensitions in specifications.Dimensitions)
                {
                    ThreeDImageDimensitionsInfo DInfo = new ThreeDImageDimensitionsInfo();
                    DInfo.ItemName = dimensitions.ItemName;
                    DInfo.RoomType = dimensitions.RoomType;
                    DInfo.Demensions = dimensitions.Dimensionss;
                    lstImages = CreateFile(dimensitions.files, specifications.CUUID);
                    DInfo.images = lstImages;
                    lstDimensions.Add(DInfo);
                }
                info.Id = Guid.NewGuid().ToString("N").Substring(0, 5);
                info.Specs = lstSpec;
                info.Dimensions = lstDimensions;
                info.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                Info.FinalViewImages = JsonSerializer.Serialize(info);
                Info.ThreeDLink = specifications.ThreeDLink;
                _context.SaveChanges();
            }
        }

        [Obsolete]
        public List<Images> CreateFile(IEnumerable<IFormFile> images,string cuuid)
        {
            string folderName = string.Empty;
            string webRootPath = _hostingEnvironment.WebRootPath;
            List<Images> lstImages = new List<Images>();
            if (images.Count()>0)
            {
                folderName = "ApplicationDocuments\\" + cuuid + "\\";
                string basePath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(basePath))
                    System.IO.Directory.CreateDirectory(basePath);
                foreach (IFormFile file in images)
                {
                    Images ObjImages = new Images();
                    ObjImages.Id = Guid.NewGuid().ToString("N").Substring(0, 5);
                    string GUID = Guid.NewGuid().ToString();
                    string fileName = file.FileName;
                    string fileExtension = Path.GetExtension(fileName);
                    fileName = GUID + fileExtension;
                    ObjImages.Name = fileName;
                    string destinationPath = Path.Combine(basePath, fileName);
                    var stream = new FileStream(destinationPath, FileMode.Create);
                    file.CopyToAsync(stream);
                    lstImages.Add(ObjImages);
                }
            }
            return lstImages;
        }
    }
}
