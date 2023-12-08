namespace RedSocial.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publicacion")]
    public partial class Publicacion
    {
        public int id { get; set; }

        public int Para { get; set; }

        public int De { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Contenido { get; set; }

        [Required]
        [StringLength(20)]
        public string FechaRegistro { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
