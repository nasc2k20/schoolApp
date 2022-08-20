using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolApp.Models;
using schoolApp.Models.viewModels;

namespace schoolApp.Controllers
{
    public class cursoGradoController : Controller
    {
        // GET: cursoGrado
        public ActionResult Index()
        {
            List<listaCourseGradeViewModel> assingnations;

            using (SchoolEntities cnn = new SchoolEntities())
            {                
                assingnations = (from csGd in cnn.CourseGrade
                                 join cs in cnn.Course on csGd.CourseId equals cs.Id
                                 join gd in cnn.Grade on csGd.GradeId equals gd.Id
                                 join st in cnn.Student on gd.Id equals st.GradeId
                                 select new listaCourseGradeViewModel
                                 {
                                     Id = csGd.Id,
                                     CourseId = csGd.CourseId,
                                     GradeId = csGd.GradeId,
                                     idGrade = gd.Id,
                                     nameGrade = gd.Name,
                                     idCourse = cs.Id,
                                     nameCourse = cs.Name,
                                     nameStudent = st.Name
                                 }).ToList();
            }


            List<listaCourseGradeViewModel> comboEstudiante = null;
            using (SchoolEntities cnn = new SchoolEntities())
            {
                comboEstudiante = (from st in cnn.Student
                              select new listaCourseGradeViewModel
                              {
                                  idStudent = st.Id,
                                  nameStudent = st.Name
                              }).ToList();
            }
            List<SelectListItem> itemComboEstudiante = comboEstudiante.ConvertAll(gde =>
            {
                return new SelectListItem()
                {
                    Text = gde.nameStudent.ToString(),
                    Value = gde.idStudent.ToString(),
                    Selected = false
                };
            });
            ViewBag.itemsCbEst = itemComboEstudiante;

            return View(assingnations);
        }
        [HttpPost]
        public ActionResult Index(int? idStudent)
        {
            List<listaCourseGradeViewModel> assingnations;

            using (SchoolEntities cnn = new SchoolEntities())
            {
                    assingnations = (from csGd in cnn.CourseGrade
                                     join cs in cnn.Course on csGd.CourseId equals cs.Id
                                     join gd in cnn.Grade on csGd.GradeId equals gd.Id
                                     join st in cnn.Student on gd.Id equals st.GradeId
                                     where st.Id == idStudent
                                     select new listaCourseGradeViewModel
                                     {
                                         Id = csGd.Id,
                                         CourseId = csGd.CourseId,
                                         GradeId = csGd.GradeId,
                                         idGrade = gd.Id,
                                         nameGrade = gd.Name,
                                         idCourse = cs.Id,
                                         nameCourse = cs.Name,
                                         nameStudent = st.Name
                                     }).ToList();
            }


            List<listaCourseGradeViewModel> comboEstudiante = null;
            using (SchoolEntities cnn = new SchoolEntities())
            {
                comboEstudiante = (from st in cnn.Student
                                   select new listaCourseGradeViewModel
                                   {
                                       idStudent = st.Id,
                                       nameStudent = st.Name
                                   }).ToList();
            }
            List<SelectListItem> itemComboEstudiante = comboEstudiante.ConvertAll(gde =>
            {
                return new SelectListItem()
                {
                    Text = gde.nameStudent.ToString(),
                    Value = gde.idStudent.ToString(),
                    Selected = false
                };
            });
            ViewBag.itemsCbEst = itemComboEstudiante;

            return View(assingnations);
        }

        public ActionResult AddCourseGrade()
        {
            List<listaCourseGradeViewModel> comboGrado = null;
            List<listaCourseGradeViewModel> comboCurso = null;

            using (SchoolEntities cnn = new SchoolEntities())
            {
                comboGrado = (from gd in cnn.Grade
                              select new listaCourseGradeViewModel
                              {
                                  idGrade = gd.Id,
                                  nameGrade = gd.Name
                              }).ToList();
            }

            using (SchoolEntities cnn = new SchoolEntities())
            {
                comboCurso = (from cs in cnn.Course
                              select new listaCourseGradeViewModel
                              {
                                  idCourse = cs.Id,
                                  nameCourse = cs.Name
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

            List<SelectListItem> itemComboCurso = comboCurso.ConvertAll(crs =>
            {
                return new SelectListItem()
                {
                    Text = crs.nameCourse.ToString(),
                    Value = crs.idCourse.ToString(),
                    Selected = false
                };
            });


            ViewBag.itemsCbG = itemComboGrado;
            ViewBag.itemsCbC = itemComboCurso;

            return View();
        }

        [HttpPost]
        public ActionResult AddCourseGrade(courseGradeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolEntities cnn = new SchoolEntities())
                    {
                        var oCourseGrade = new CourseGrade();
                        oCourseGrade.CourseId = model.CourseId;
                        oCourseGrade.GradeId = model.GradeId;
                        cnn.CourseGrade.Add(oCourseGrade);
                        cnn.SaveChanges();
                    }
                    return Redirect("~/cursoGrado/");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(model);
        }

        public ActionResult EditCourseGrade(int id)
        {
            courseGradeViewModel model = new courseGradeViewModel();
            using (SchoolEntities cnn = new SchoolEntities())
            {
                var oCourseGrade = cnn.CourseGrade.Find(id);
                model.CourseId = oCourseGrade.CourseId;
                model.GradeId = oCourseGrade.GradeId;
                model.Id = oCourseGrade.Id;
            }



            List<listaCourseGradeViewModel> comboGrado = null;
            List<listaCourseGradeViewModel> comboCurso = null;

            using (SchoolEntities cnn = new SchoolEntities())
            {
                comboGrado = (from gd in cnn.Grade
                              select new listaCourseGradeViewModel
                              {
                                  idGrade = gd.Id,
                                  nameGrade = gd.Name
                              }).ToList();
            }

            using (SchoolEntities cnn = new SchoolEntities())
            {
                comboCurso = (from cs in cnn.Course
                              select new listaCourseGradeViewModel
                              {
                                  idCourse = cs.Id,
                                  nameCourse = cs.Name
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

            List<SelectListItem> itemComboCurso = comboCurso.ConvertAll(crs =>
            {
                return new SelectListItem()
                {
                    Text = crs.nameCourse.ToString(),
                    Value = crs.idCourse.ToString(),
                    Selected = false
                };
            });


            ViewBag.itemsCbG = itemComboGrado;
            ViewBag.itemsCbC = itemComboCurso;


            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourseGrade(courseGradeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolEntities cnn = new SchoolEntities())
                    {
                        var oCourseGrade = cnn.CourseGrade.Find(model.Id);
                        oCourseGrade.GradeId = model.GradeId;
                        oCourseGrade.CourseId = model.CourseId;
                        oCourseGrade.Id = model.Id;
                        cnn.Entry(oCourseGrade).State = System.Data.Entity.EntityState.Modified;
                        cnn.SaveChanges();
                    }

                    return Redirect("~/cursoGrado/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult DeleteCourseGrade(int id)
        {
            using (SchoolEntities cnn = new SchoolEntities())
            {
                var oCourseGrade = cnn.CourseGrade.Find(id);
                cnn.CourseGrade.Remove(oCourseGrade);
                cnn.SaveChanges();
            }

            return Redirect("~/cursoGrado/");
        }
    }
}