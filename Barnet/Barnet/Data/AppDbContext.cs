using Barnet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barnet.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Service_Category> Service_Categories { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Serv_Project_Category> serv_Project_Categories { get; set; }
        public DbSet<Service_Project> Service_Projects { get; set; }

    }
}
