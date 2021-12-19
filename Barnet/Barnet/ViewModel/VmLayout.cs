using Barnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barnet.ViewModel
{
    public class VmLayout
    {
        public Setting Setting { get; set; }
        public List<Social> Socials { get; set; }
        public List<Banner> Banners { get; set; }

    }
}
