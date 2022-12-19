using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiEjemploDDD.Domain;
using MiEjemploDDD.Infrastructure.Repositories;
using System.Reflection.Emit;

namespace MiEjemploDDD.Infrastructure.Persistence
{
    public class MiEjemploDDDDbContext : DbContext
    {


        public MiEjemploDDDDbContext(DbContextOptions<MiEjemploDDDDbContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("MiTramite");


        }

        public DbSet<VehiculoTipo>? VehiculoTipos { get; set; }


    }
}
