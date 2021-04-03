using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MsSQL
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<User_PSW> PSWs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PDFlist> PDFlists { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Article_Statistics> Article_Statistics { get; set; }
    }
}
