using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace schoolApp.Models.viewModels
{
    public class studentsViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name="Codigo de Estudiante")]
        public string StudentCode { get; set; }
        [Required]
        [Display(Name = "Nombre de Estudiante")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Grado")]
        public int GradeId { get; set; }
        [Required]
        public string Comments { get; set; }

    }
}