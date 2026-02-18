using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace API_Rest_Para_Consulta_de_Datos.Data
{
    public class Contexto : IdentityDbContext<UsuarioAplicacion>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Contribucion> Contribuciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Portfolio>()
                .HasKey(p => new { p.MiembroID, p.DepartamentoID });
            modelBuilder.Entity<Portfolio>()
                .HasOne(p => p.Miembro)
                .WithMany(m => m.Portfolios)
                .HasForeignKey(p => p.MiembroID);
            modelBuilder.Entity<Portfolio>()
                .HasOne(p => p.Departamento)
                .WithMany(d => d.Portfolios)
                .HasForeignKey(p => p.DepartamentoID);

            List<IdentityRole> Roles = new List<IdentityRole>()
           {
                new IdentityRole
                {
                    Id ="1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },

                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
           };
           modelBuilder.Entity<IdentityRole>().HasData(Roles);
        }
    }
}
