namespace RedSocial.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuario")]
    public class Usuario
    {
        public int id { get; set; }

        public byte Admin { get; set; }

        [Required]
        [StringLength(50)]
        public string Correo { get; set; }

        [Required]
        [StringLength(32)]
        public string Contrasena { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public byte? Sexo { get; set; }

        [StringLength(10)]
        public string FechaNacimiento { get; set; }

        [StringLength(200)]
        public string Url { get; set; }
    }
}
