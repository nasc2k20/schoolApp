using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolApp.Models;
using schoolApp.Models.viewModels;

namespace schoolApp.Controllers
{
    public class cursoController : Controller
    {
        // GET: curso
        public ActionResult Index()
        {
            List<listaCourseViewModel> courses;

            using (SchoolEntities cnn = new SchoolEntities())
            {
                courses = (from dCourses in cnn.Course
                           select new listaCourseViewModel
                           {
                               Id = dCourses.Id,
                               Name = dCourses.Name
                           }).ToList();
            }
            
            return View(courses);
        }

        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(coursesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolEntities cnn = new SchoolEntities())
                    {
                        var oCourses = new Course();
                        oCourses.Name = model.Name.ToUpper();
                        cnn.Course.Add(oCourses);
                        cnn.SaveChanges();
                    }

                    return Redirect("~/curso/");
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(model);
        }

        public ActionResult EditCourse(int id)
        {
            coursesViewModel model = new coursesViewModel();

            using (SchoolEntities cnn = new SchoolEntities())
            {
                var oCourse = cnn.Course.Find(id);
                model.Name = oCourse.Name.ToUpper();
                model.Id = oCourse.Id;
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourse (coursesViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (SchoolEntities cnn = new SchoolEntities())
                    {
                        var oCourse = cnn.Course.Find(model.Id);
                        oCourse.Id = model.Id;
                        oCourse.Name = model.Name.ToUpper();

                        cnn.Entry(oCourse).State = System.Data.Entity.EntityState.Modified;
                        cnn.SaveChanges();
                    }

                    return Redirect("~/curso/");
                }

                return View(model);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            using (SchoolEntities cnn= new SchoolEntities())
            {
                var oCourse = cnn.Course.Find(id);
                cnn.Course.Remove(oCourse);
                cnn.SaveChanges();
            }

            return Redirect("~/curso/");
        }
    }
}