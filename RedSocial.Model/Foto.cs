namespace RedSocial.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Foto")]
    public partial class Foto
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string Relacion { get; set; }

        [Required]
        [StringLength(20)]
        public string Foto1 { get; set; }

        [Required]
        [StringLength(20)]
        public string Foto2 { get; set; }

        [Required]
        [StringLength(20)]
        public string Foto3 { get; set; }

        [Required]
        [StringLength(20)]
        public string FechaRegistro { get; set; }
    }
}
