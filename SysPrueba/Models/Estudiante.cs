using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysPrueba.Models
{
    public class Estudiante
    {
        [Key]
        public int idEstudiante { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(255,ErrorMessage = "El campo {0} solo guarda 255 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(255, ErrorMessage = "El campo {0} solo guarda 255 caracteres")]
        public string Apellidos { get; set; }

        public bool Status { get; set; }

        public List<Telefono> Telefonos { get; set; }
    }
}