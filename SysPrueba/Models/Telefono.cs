using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysPrueba.Models
{
    public class Telefono
    {
        [Key]
        public int idTelefono { get; set; }

        public int Estudiante_id { get; set; }

        [StringLength(8,ErrorMessage = "Limite de 8 caracteres")]
        public string Telf { get; set; }

        [ForeignKey("Estudiante_id")]
        public Estudiante Estudiante { get; set; }
    }
}