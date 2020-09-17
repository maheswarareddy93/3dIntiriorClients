using System.ComponentModel.DataAnnotations;

namespace _3dIntiriorClients.Models
{
    public class CustomerInfo
    {
        [Key]
        public int Customerid { get; set; }
        public string Customername { get; set; }
        public string Emailid { get; set; }
        public string Mobileno { get; set; }
        public string LeadType { get; set; }
        public sbyte? IsActive { get; set; }
        public string Password { get; set; }

        public string CreatedDate { get; set; }
    }
}
