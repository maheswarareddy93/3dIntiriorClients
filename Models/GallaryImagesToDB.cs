using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Models
{
    public class GallaryImagesToDB
    {
      public int Id { get; set; }
      public string RoomType { get; set; }
       
      public List<GallaryImage> lstImages { get; set; }
       
    }
    public class GallaryImage
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}
