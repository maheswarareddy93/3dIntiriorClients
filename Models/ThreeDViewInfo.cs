using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Models
{
    public class ThreeDViewInfo
    {
        public string Id { get; set; }
        public List<SpecificationsInfo> Specs { get; set; }
        public List<ThreeDImageDimensitionsInfo> Dimensions { get; set; }
        public string CreatedDate { get; set; }
    }
    public class SpecificationsInfo
    {
       public string ElementName { get; set; }
       public string Brand { get; set; }
        public string ProductLink { get; set; }
        public List<Images> images { get; set; }
    }
    public class ThreeDImageDimensitionsInfo
    {
        public string RoomType { get; set; }
        public string ItemName { get; set; }
        public string Demensions { get; set; }
        public List<Images> images { get; set; }
    }
}
