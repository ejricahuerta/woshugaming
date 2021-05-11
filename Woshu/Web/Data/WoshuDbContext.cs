using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data.Models;

namespace Web.Data
{
    public class WoshuDbContext : DbContext
    {
        public DbSet<StreamVideo> StreamVideos { get; set; }
        public WoshuDbContext( DbContextOptions<WoshuDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

}
