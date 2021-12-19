using Barnet.Data;
using Barnet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Barnet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Service_Project> service_Projects= _appDbContext.Service_Projects.Include(sp=>sp.Serv_Project_Category).ToList();
            return View(service_Projects);
        }
        public IActionResult Create()
        {
            ViewBag.Service_Project_Categories = _appDbContext.serv_Project_Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service_Project service_Project)
        {
            if (ModelState.IsValid)
            {
                if (service_Project.ImageFile != null)
                {
                    if (service_Project.ImageFile.ContentType == "image/png" || service_Project.ImageFile.ContentType == "image/jpeg")
                    {
                        if (service_Project.ImageFile.Length <= 2097152)
                        {

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + service_Project.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                service_Project.ImageFile.CopyTo(stream);
                            }
                            service_Project.Image = fileName;

                            _appDbContext.Service_Projects.Add(service_Project);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb.");
                            return View(service_Project);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        return View(service_Project);

                    }
                }
                else
                {
                    
                    _appDbContext.Service_Projects.Add(service_Project);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

          
            return View(service_Project);
        }
        public IActionResult Update(int? id)
        {
            Service_Project service_Project = _appDbContext.Service_Projects.Include(sp => sp.Serv_Project_Category).FirstOrDefault(i=>i.Id==id);
            ViewBag.Service_Project_Categories = _appDbContext.serv_Project_Categories.ToList();
            return View(service_Project);
        }
        [HttpPost]
        public IActionResult Update(Service_Project service_Project)
        {
            if (ModelState.IsValid)
            {
                if (service_Project.ImageFile != null)
                {
                    if (service_Project.ImageFile.ContentType == "image/png" || service_Project.ImageFile.ContentType == "image/jpeg")
                    {
                        if (service_Project.ImageFile.Length <= 2097152)
                        {
                            if (!string.IsNullOrEmpty(service_Project.Image))
                            {
                                string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", service_Project.Image);

                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }
                            }

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + service_Project.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                service_Project.ImageFile.CopyTo(stream);
                            }

                            service_Project.Image = fileName;
                            ViewBag.Service_Project_Categories = _appDbContext.serv_Project_Categories.ToList();

                            _appDbContext.Service_Projects.Update(service_Project);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    ViewBag.Service_Project_Categories = _appDbContext.serv_Project_Categories.ToList();

                    _appDbContext.Service_Projects.Update(service_Project);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }


            return View(service_Project);
        }
        public IActionResult Delete(int? id)
        {
            Service_Project service_Project = _appDbContext.Service_Projects.Find(id);

            if (id != null)
            {
                string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", service_Project.Image);

                if (!string.IsNullOrEmpty(service_Project.Image))
                {
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }
            }
            _appDbContext.Service_Projects.Remove(service_Project);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");

        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Serv_Project_Category serv_Project_Category)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.serv_Project_Categories.Add(serv_Project_Category);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(serv_Project_Category);
        }
    }
}
