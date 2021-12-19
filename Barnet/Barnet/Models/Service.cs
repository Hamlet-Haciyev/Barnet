using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Barnet.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(1000)]
        public string Content { get; set; }
        [MaxLength(30)]
        public string Icon { get; set; }
        [ForeignKey("Service_Category")]
        public int Service_Category_Id { get; set; }
        public Service_Category Service_Category { get; set; }

    }
}
