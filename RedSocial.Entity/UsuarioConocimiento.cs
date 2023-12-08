using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Entity
{
    [Table("UsuarioConocimiento")]
    public class UsuarioConocimiento
    {
        [Key, Column(Order = 0), ForeignKey("Conocimiento")]
        public int Conocimiento_id { get; set; }
        public Conocimiento Conocimiento { get; set; }

        [Key, Column(Order = 1), ForeignKey("Usuario")]
        public int Usuario_id { get; set; }
        public Usuario Usuario { get; set; }
    }
}
