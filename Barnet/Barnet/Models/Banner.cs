using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Barnet.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Page { get; set; }
        [MaxLength(250)]
        public string Bg_Image { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }

    }
}
