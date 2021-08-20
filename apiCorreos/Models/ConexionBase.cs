using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiCorreos.Models
{
    public partial class ConexionBase : DbContext
    {
        public ConexionBase()
            : base("name=ConexionBase")
        {
        }

        public virtual DbSet<Servicios_Correo> Servicios_Correo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicios_Correo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Servicios_Correo>()
                .Property(e => e.Propietario)
                .IsUnicode(false);

            modelBuilder.Entity<Servicios_Correo>()
                .Property(e => e.Desarrollador)
                .IsUnicode(false);
        }
    }
}
