using Barnet.Data;
using Barnet.Models;
using Barnet.ViewModel;
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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(AppDbContext appDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            
            List<Service> services = _appDbContext.Services.Include(s => s.Service_Category).ToList();
            List<FeedBack> feedBacks = _appDbContext.FeedBacks.ToList();
            List<Social> socials = _appDbContext.Socials.ToList();
            List<Banner> banners = _appDbContext.Banners.ToList();

            Setting setting = _appDbContext.Settings.FirstOrDefault();

            VmService vmService = new VmService()
            {
                Services = services,
                FeedBacks = feedBacks,
                Socials = socials,
                Banners = banners,
                Setting=  setting
            };

            return View(vmService);
        }
        public IActionResult Create()
        {
            ViewBag.ServiceCategories = _appDbContext.Service_Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                if (service.ImageFile != null)
                {
                    if (service.ImageFile.ContentType == "image/png" || service.ImageFile.ContentType == "image/jpeg")
                    {
                        if (service.ImageFile.Length <= 2097152)
                        {

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + service.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                service.ImageFile.CopyTo(stream);
                            }
                            Service service1 = new Service()
                            {
                                Content = service.Content,
                                Icon=service.Icon,
                                Image=fileName,
                                Service_Category_Id=service.Service_Category_Id,
                                
                            };
                            _appDbContext.Services.Add(service1);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb.");
                            return View(service);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        return View(service);

                    }
                }
                else
                {
                    Service service1 = new Service()
                    {
                        Content = service.Content,
                        Icon = service.Icon,
                        Service_Category_Id = service.Service_Category_Id,
                    };
                    _appDbContext.Services.Add(service1);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            return View(service);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Service_Category category)
        {
            if (ModelState.IsValid)
            {
                if (category != null)
                {
                    _appDbContext.Service_Categories.Add(category);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(category);
                }
            }


            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            Service service = _appDbContext.Services.Find(id);

            if (id!=null)
            {
                string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", service.Image);

                if (!string.IsNullOrEmpty(service.Image))
                {
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }
            }
            _appDbContext.Services.Remove(service);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            Service service = _appDbContext.Services.Include(s => s.Service_Category).FirstOrDefault(i=>i.Id==id);
            ViewBag.Service_Categories = _appDbContext.Service_Categories.ToList();

            return View(service);
        }
        [HttpPost]
        public IActionResult Update(Service service)
        {
            if (ModelState.IsValid)
            {
                if (service.ImageFile!=null)
                {
                    if (service.ImageFile.ContentType=="image/png"|| service.ImageFile.ContentType == "image/jpeg")
                    {
                        if (service.ImageFile.Length <= 2097152)
                        {
                            if (!string.IsNullOrEmpty(service.Image))
                            {
                                string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", service.Image);

                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }
                            }

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + service.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                service.ImageFile.CopyTo(stream);
                            }

                            service.Image = fileName;
                            ViewBag.Service_Categories = _appDbContext.Service_Categories.ToList();

                            _appDbContext.Services.Update(service);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    ViewBag.Service_Categories = _appDbContext.Service_Categories.ToList();

                    _appDbContext.Services.Update(service);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }


            return View(service);
        }


        #region FeedBack
        public IActionResult FeedBackIndex()
        {
            List<FeedBack> feedBacks = _appDbContext.FeedBacks.ToList();

            VmService vmService = new VmService()
            {
                FeedBacks = feedBacks
            };

            return View(vmService);
        }
        public IActionResult FeedBackCreate()
        {

            return View();
        }
        [HttpPost]
        public IActionResult FeedBackCreate(FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                if (feedBack.ImageFile!=null)
                {
                    if (feedBack.ImageFile.ContentType=="image/png"|| feedBack.ImageFile.ContentType == "image/jpeg")
                    {
                        if (feedBack.ImageFile.Length <= 2097152)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + feedBack.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                feedBack.ImageFile.CopyTo(stream);
                            }
                            feedBack.Image = fileName;

                            _appDbContext.FeedBacks.Add(feedBack);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("FeedBackIndex");

                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb.");
                            return View(feedBack);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        return View(feedBack);

                    }

                }
                else
                {
                    _appDbContext.FeedBacks.Add(feedBack);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(feedBack);
        }
        public IActionResult FeedBackDelete(int? id)
        {
            FeedBack feedBack = _appDbContext.FeedBacks.Find(id);

            if (id != null)
            {
                string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", feedBack.Image);

                if (!string.IsNullOrEmpty(feedBack.Image))
                {
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }
            }
            _appDbContext.FeedBacks.Remove(feedBack);
            _appDbContext.SaveChanges();
            return RedirectToAction("FeedBackIndex");
        }

        public IActionResult FeedBackUpdate(int? id)
        {
            FeedBack feedBack = _appDbContext.FeedBacks.FirstOrDefault(i => i.Id == id);
           
            return View(feedBack);
        }
        [HttpPost]
        public IActionResult FeedBackUpdate(FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                if (feedBack.ImageFile != null)
                {
                    if (feedBack.ImageFile.ContentType == "image/png" || feedBack.ImageFile.ContentType == "image/jpeg")
                    {
                        if (feedBack.ImageFile.Length <= 2097152)
                        {
                            if (!string.IsNullOrEmpty(feedBack.Image))
                            {
                                string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", feedBack.Image);

                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }
                            }

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + feedBack.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                feedBack.ImageFile.CopyTo(stream);
                            }

                            feedBack.Image = fileName;

                            _appDbContext.FeedBacks.Update(feedBack);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {

                    _appDbContext.FeedBacks.Update(feedBack);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }


            return View(feedBack);
        }

        #endregion

       
    }
}
