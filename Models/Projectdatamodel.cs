using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _3dIntiriorClients.Models
{
    public class Projectdatamodel
    {
        public string projectId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public string ProjectName { get; set; }

        public string Type { get; set; }
        [Required]
        public string Unitsize { get; set; }
        public int Id { get; set; }
        public List<PropertyTypes> SelectUnitType { get; set; }
        public string Room1 { get; set; }
        public string Room2 { get; set; }
        public string Room3 { get; set; }
        public string Room4 { get; set; }
        public string Room5 { get; set; }
        public string Room6 { get; set; }
        public string Room7 { get; set; }
        public string Room8 { get; set; }
        public string Room9 { get; set; }
        public string Room10 { get; set; }
        public string Room11 { get; set; }
        public string Room12 { get; set; }
        public string Room13 { get; set; }
        public string Room14 { get; set; }
        public string comments1 { get; set; }
        public string comments2 { get; set; }
        public string comments3 { get; set; }
        public string comments4 { get; set; }
        public string comments5 { get; set; }
        public string comments6 { get; set; }
        public string comments7 { get; set; }
        public string comments8 { get; set; }
        public string comments9 { get; set; }
        public string comments10 { get; set; }
        public string comments11 { get; set; }
        public string comments12 { get; set; }
        public string comments13 { get; set; }
        public string comments14 { get; set; }
        public IEnumerable<IFormFile> Attachments1 { get; set; }
        public IEnumerable<IFormFile> Attachments2 { get; set; }


        public IEnumerable<IFormFile> Attachments3 { get; set; }
        public IEnumerable<IFormFile> Attachments4 { get; set; }
        public IEnumerable<IFormFile> Attachments5 { get; set; }

        public IEnumerable<IFormFile> Attachments6 { get; set; }
        public IEnumerable<IFormFile> Attachments7 { get; set; }
        public IEnumerable<IFormFile> Attachments8 { get; set; }
        public IEnumerable<IFormFile> Attachments9 { get; set; }
        public IEnumerable<IFormFile> Attachments10 { get; set; }
        public IEnumerable<IFormFile> Attachments11 { get; set; }
        public IEnumerable<IFormFile> Attachments12 { get; set; }
        public IEnumerable<IFormFile> Attachments13 { get; set; }
        public IEnumerable<IFormFile> Attachments14 { get; set; }

        public int count { get; set; }
        public IEnumerable<IFormFile> Attachments { get; set; }
        public IEnumerable<IFormFile> Attachment { get; set; }

        public string CUUID { get; set; }

    }
}
