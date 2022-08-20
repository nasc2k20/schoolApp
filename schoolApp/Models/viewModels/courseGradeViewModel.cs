using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace schoolApp.Models.viewModels
{
    public class courseGradeViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre del Grado")]
        public int GradeId { get; set; }
        [Required]
        [Display(Name = "Nombre del Curso")]
        public int CourseId { get; set; }
    }
}