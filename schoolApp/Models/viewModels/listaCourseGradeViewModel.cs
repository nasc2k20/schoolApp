using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolApp.Models.viewModels
{
    public class listaCourseGradeViewModel
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public int CourseId { get; set; }

        public int idGrade { get; set; }
        public string nameGrade { get; set; }

        public int idCourse { get; set; }
        public string nameCourse { get; set; }

        public int idStudent { get; set; }
        public string nameStudent { get; set; }
    }
}