using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ratings2_2.Models;

namespace Ratings2_2.Data
{
    public class Ratings2_2Context : DbContext
    {
        public Ratings2_2Context (DbContextOptions<Ratings2_2Context> options)
            : base(options)
        {
        }

        public DbSet<Ratings2_2.Models.RatingObj>? RatingObj { get; set; }
    }
}
