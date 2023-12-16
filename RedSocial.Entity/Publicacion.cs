namespace RedSocial.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Publicacion")]
    public class Publicacion
    {
        public int id { get; set; }

        public int Para { get; set; }

        public int De { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Contenido { get; set; }

        [StringLength(20)]
        public string FechaRegistro { get; set; }

        [NotMapped] // Para que no aparezca en la consulta
        public Usuario Emisor { get; set; }

        [NotMapped] // Para que no aparezca en la consulta
        public Usuario Receptor { get; set; }
    }
}
