using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppApi.Models;

namespace WebAppApi.Data
{
    public class WebAppApiContext : DbContext
    {
        public WebAppApiContext (DbContextOptions<WebAppApiContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppApi.Models.Contact>? Contact { get; set; }

        public DbSet<WebAppApi.Models.Message> Message { get; set; }
    }
}
