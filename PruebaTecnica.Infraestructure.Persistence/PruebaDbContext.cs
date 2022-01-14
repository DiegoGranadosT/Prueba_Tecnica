using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaTecnica.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infraestructure.Persistence
{
    public class PruebaDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public PruebaDbContext()
        {

        }

        public PruebaDbContext(DbContextOptions<PruebaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
