using System.Collections.Generic;

namespace _3dIntiriorClients.Models
{
    public class ReferenceImages
    {
        public string Id { get; set; }
        public string RoomType { get; set; }
        public string Comments { get; set; }
        public List<Images> ReferenceImg { get; set; }
        public string CreatedDate { get; set; }
    }
    public class Images
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class RootImg
    {
        public List<ReferenceImages> list { get; set; }
    }
}
