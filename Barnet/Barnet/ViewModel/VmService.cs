using Barnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barnet.ViewModel
{
    public class VmService :VmLayout
    {
        public List<Service> Services { get; set; }
        public List<FeedBack> FeedBacks { get; set; }
        public List<Service_Project> Service_Projects { get; set; }
    }
}
