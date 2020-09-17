using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Models
{
    public class ThreeDSpecUpdate
    {
        public string Id { get; set; }
        public string ThreeDLink { get; set; }
        public  List<Specifications> Specification { get; set; }
        public List<ThreeDImageDimensitions> Dimensitions { get; set; }
        public string CUUID { get; set; }
    }
    public class Specifications
    {
        public string SpecId { get; set; }
        public string ElementName { get; set; }
        public string Brand { get; set; }
        public string ProductLink { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }

    }

    public class ThreeDImageDimensitions
    {
        public string RoomType { get; set; }
        public  string  ItemName { get; set; }
        public string Dimensionss { get; set; }
        public IEnumerable<IFormFile> files { get; set; }
    }    
}
