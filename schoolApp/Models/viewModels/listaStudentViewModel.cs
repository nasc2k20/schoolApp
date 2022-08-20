using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolApp.Models.viewModels
{
    public class listaStudentViewModel
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string NameStudent { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string GradeName { get; set; }

        public int idGrade { get; set; }
        public string nameGrade { get; set; }
    }
}