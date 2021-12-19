using Barnet.Data;
using Barnet.Models;
using Barnet.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barnet.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ServiceController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<FeedBack> feedBacks = _appDbContext.FeedBacks.ToList();
            List<Service_Project> service_Projects = _appDbContext.Service_Projects.Include(sp => sp.Serv_Project_Category).ToList();
            List<Service> services = _appDbContext.Services.Include(s=>s.Service_Category).ToList();
            ViewBag.Serv_Project_Category = _appDbContext.serv_Project_Categories.ToList();
            VmService vmService = new VmService()
            {
                FeedBacks = feedBacks,
                Service_Projects= service_Projects,
                Services = services
            };
            return View(vmService);
        }
    }
}
