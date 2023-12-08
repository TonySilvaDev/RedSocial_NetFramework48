namespace RedSocial.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Foto")]
    public class Foto
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

        public Foto()
        {
            Foto1 = "no-photo.jpg";
            Foto2 = "no-photo.jpg";
            Foto3 = "no-photo.jpg";
        }
    }
}
