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
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Blog> blogs = _appDbContext.Blogs.Include(b=>b.Categories).ToList();

            return View(blogs);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _appDbContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                if (blog.ImageFile != null)
                {
                    if (blog.ImageFile.ContentType == "image/png" || blog.ImageFile.ContentType == "image/jpeg")
                    {
                        if (blog.ImageFile.Length <= 2097152)
                        {

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + blog.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                blog.ImageFile.CopyTo(stream);
                            }
                            Blog blog1 = new Blog()
                            {
                                Title = blog.Title,
                                Description = blog.Description,
                                CreatedDate = DateTime.Now,
                                UserId = 1,
                                CategorieId = blog.CategorieId,
                                Image = fileName
                            };
                            _appDbContext.Blogs.Add(blog1);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb.");
                            return View(blog);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        return View(blog);

                    }
                }
                else
                {
                    Blog blog1 = new Blog()
                    {
                        Title = blog.Title,
                        Description = blog.Description,
                        CreatedDate = DateTime.Now,
                        UserId = 1,
                        CategorieId = blog.CategorieId,
                    };
                    _appDbContext.Blogs.Add(blog1);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            return View(blog);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                if (categorie != null)
                {
                    Categorie categorie1 = new Categorie()
                    {
                        Name = categorie.Name
                    };
                    _appDbContext.Categories.Add(categorie1);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(categorie);
                }
            }


            return View(categorie);
        }
        public IActionResult Delete(int? id)
        {
            Blog blog = _appDbContext.Blogs.Find(id);


            if (id!=null)
            {

                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", blog.Image);

                if (!string.IsNullOrEmpty(blog.Image))
                {
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                

                _appDbContext.Blogs.Remove(blog);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index", "Blog");
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            Blog blog = _appDbContext.Blogs.Include(b=>b.Categories).Include(b=>b.User).FirstOrDefault(i=>i.Id==id);

            ViewBag.Categories = _appDbContext.Categories.ToList();
            return View(blog);
        }
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            

            if (ModelState.IsValid)
            {
                if (blog.ImageFile != null)
                {
                    if (blog.ImageFile.ContentType == "image/png" || blog.ImageFile.ContentType == "image/jpeg")
                    {
                        if (blog.ImageFile.Length <= 2097152)
                        {


                            if (!string.IsNullOrEmpty(blog.Image))
                            {
                                string oldPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", blog.Image);

                                if (System.IO.File.Exists(oldPathFile))
                                {
                                    System.IO.File.Delete(oldPathFile);
                                }
                            }


                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + blog.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                blog.ImageFile.CopyTo(stream);
                            }

                            blog.Image = fileName;

                            ViewBag.Categories = _appDbContext.Categories.ToList();

                            _appDbContext.Blogs.Update(blog);
                            _appDbContext.SaveChanges();

                            return RedirectToAction("Index");
                        }
                       
                    }
                   
                }
                else
                {

                    ViewBag.Categories = _appDbContext.Categories.ToList();

                    

                    _appDbContext.Blogs.Update(blog);
                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }



            return View(blog);
        }
    }
}
