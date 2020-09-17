using System.ComponentModel.DataAnnotations;
namespace _3dIntiriorClients.Models
{
    public class ProjectDataInfo
    {
        [Key]
        public int Id { get; set; }
        public string Projectname { get; set; }
        public string UnitType { get; set; }
        public string UnitSize { get; set; }
        public string Referenceimages { get; set; }
        public int CustomerId { get; set; }
        public string Finalimage { get; set; }
        public string cuuid { get; set; }
        public string CreatedDate { get; set; }

        public string FinalViewImages { get; set; }
        public string PaymentStatus { get; set; }
        public string ThreeDLink { get; set; }
    }
}
