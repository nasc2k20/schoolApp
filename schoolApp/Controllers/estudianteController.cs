using schoolApp.Models;
using schoolApp.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schoolApp.Controllers
{
    public class estudianteController : Controller
    {
        // GET: estudiante
        public ActionResult Index()
        {
            List<listaStudentViewModel> students;
            

            using (SchoolEntities cnn = new SchoolEntities()) {

                students = (from st in cnn.Student
                           join gd in cnn.Grade on st.GradeId equals gd.Id
                           select new listaStudentViewModel
                           { 
                               Id = st.Id,
                               NameStudent = st.Name,
                               StudentCode = st.StudentCode,
                               BirthDate = st.BirthDate,
                               Gender = st.Gender,
                               GradeName = gd.Name
                           }).ToList();
            }

            return View(students);
        }

        public ActionResult AddStudent()
        {
            List<listaStudentViewModel> comboGrado = null;
            using (SchoolEntities cnn = new SchoolEntities())
            {
                comboGrado = (from gde in cnn.Grade
                              select new listaStudentViewModel
                              {
                                  idGrade = gde.Id,
                                  nameGrade = gde.Name
                              }).ToList();
            }

            List<SelectListItem> itemComboGrado = comboGrado.ConvertAll(gde =>
            {
                return new SelectListItem()
                {
                    Text = gde.nameGrade.ToString(),
                    Value = gde.idGrade.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsCombo = itemComboGrado;
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent (studentsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(SchoolEntities cnn = new SchoolEntities())
                    {
                        var oStudent = new Student();
                        oStudent.Name = model.Name.ToUpper();
                        oStudent.StudentCode = model.StudentCode.ToUpper();
                        oStudent.BirthDate = model.BirthDate;
                        oStudent.Gender = model.Gender.ToUpper();
                        oStudent.Comments = model.Comments.ToUpper();
                        oStudent.GradeId = model.GradeId;
                        cnn.Student.Add(oStudent);
                        cnn.SaveChanges();
                    }
                    return Redirect("~/estudiante/");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(model);
        }

        public ActionResult EditStudent(int id)
        {
           List<listaStudentViewModel> comboGrado = null;
            using (SchoolEntities cnn = new SchoolEntities())
            {
                comboGrado = (from gde in cnn.Grade
                              select new listaStudentViewModel
                              {
                                  idGrade = gde.Id,
                                  nameGrade = gde.Name
                              }).ToList();
            }

            List<SelectListItem> itemComboGrado = comboGrado.ConvertAll(gde =>
            {
                return new SelectListItem()
                {
                    Text = gde.nameGrade.ToString(),
                    Value = gde.idGrade.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsCombo = itemComboGrado;



            studentsViewModel model = new studentsViewModel();

            using(SchoolEntities cnn = new SchoolEntities())
            {
                var oStudent = cnn.Student.Find(id);
                model.Id = oStudent.Id;
                model.Name = oStudent.Name;
                model.StudentCode = oStudent.StudentCode;
                model.BirthDate = oStudent.BirthDate;
                model.Gender = oStudent.Gender;
                model.Comments = oStudent.Comments;
                model.GradeId = oStudent.GradeId;
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStudent(studentsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(SchoolEntities cnn = new SchoolEntities())
                    {
                        var oStudent = cnn.Student.Find(model.Id);
                        oStudent.Id = model.Id;
                        oStudent.Name = model.Name.ToUpper();
                        oStudent.StudentCode = model.StudentCode.ToUpper();
                        oStudent.BirthDate = model.BirthDate;
                        oStudent.Gender = model.Gender.ToUpper();
                        oStudent.Comments = model.Comments.ToUpper();
                        oStudent.GradeId = model.GradeId;

                        cnn.Entry(oStudent).State = System.Data.Entity.EntityState.Modified;
                        cnn.SaveChanges();
                    }

                    return Redirect("~/estudiante/");
                }
                
                return View(model);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            using(SchoolEntities cnn = new SchoolEntities())
            {
                var oStudent = cnn.Student.Find(id);
                cnn.Student.Remove(oStudent);
                cnn.SaveChanges();
            }

            return Redirect("~/estudiante/");
        }
    }
}