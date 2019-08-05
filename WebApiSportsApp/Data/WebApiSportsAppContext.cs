using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSportsApp.Models;

namespace WebApiSportsApp.Models
{
    public class WebApiSportsAppContext : DbContext
    {
        public WebApiSportsAppContext (DbContextOptions<WebApiSportsAppContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiSportsApp.Models.Test> Test { get; set; }

        public DbSet<WebApiSportsApp.Models.TestDetail> TestDetail { get; set; }
    }
}
