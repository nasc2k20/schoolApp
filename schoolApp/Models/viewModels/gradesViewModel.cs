using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace schoolApp.Models.viewModels
{
    public class gradesViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Digite el Nombre")]
        public string Name { get; set; }
    }
}