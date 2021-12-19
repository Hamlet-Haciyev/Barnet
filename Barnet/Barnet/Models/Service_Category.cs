using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Barnet.Models
{
    public class Service_Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength]
        public string Name { get; set; }
        public List<Service> Services { get; set; }
    }
}
