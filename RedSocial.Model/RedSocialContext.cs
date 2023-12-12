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

        public virtual DbSet<Conocimiento> Conocimiento { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<Publicacion> Publicacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // No pluralizar los terminos
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}
