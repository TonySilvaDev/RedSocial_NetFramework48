using RedSocial.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace RedSocial.Model
{
    public partial class RedSocialContext : DbContext
    {
        public RedSocialContext()
            : base("name=RedSocialDB")
        {
        }

        public DbSet<Conocimiento> Conocimiento { get; set; }
        public DbSet<Foto> Foto { get; set; }
        public DbSet<UsuarioConocimiento> UsuarioConocimiento { get; set; }
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // No pluralizar los terminos
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}
