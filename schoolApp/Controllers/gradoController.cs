using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolApp.Models;
using schoolApp.Models.viewModels;

namespace schoolApp.Controllers
{
    public class gradoController : Controller
    {
        // GET: grado
        public ActionResult Index()
        {
            List<listaGradeViewModel> grades;

            using(SchoolEntities cnn = new SchoolEntities())
            {
                grades = (from dGrade in cnn.Grade
                         select new listaGradeViewModel
                         {
                             Id = dGrade.Id,
                             Name = dGrade.Name
                         }).ToList();
            }

            return View(grades);
        }

        public ActionResult addGrade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGrade(gradesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolEntities cnn = new SchoolEntities())
                    {
                        var oGrades = new Grade();
                        oGrades.Name = model.Name.ToUpper();

                        cnn.Grade.Add(oGrades);
                        cnn.SaveChanges();
                    }

                    return Redirect("~/grado/");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
            return View(model);
        }

        public ActionResult editGrade(int id)
        {
            gradesViewModel model = new gradesViewModel();

            using(SchoolEntities cnn = new SchoolEntities())
            {
                var oGrade = cnn.Grade.Find(id);
                model.Name = oGrade.Name.ToUpper();
                model.Id = oGrade.Id;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult editGrade(gradesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolEntities cnn = new SchoolEntities())
                    {
                        var oGrade = cnn.Grade.Find(model.Id);
                        oGrade.Name = model.Name;

                        cnn.Entry(oGrade).State = System.Data.Entity.EntityState.Modified;
                        cnn.SaveChanges();
                    }

                    return Redirect("~/grado/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        [HttpGet]
        public ActionResult deleteGrade(int id)
        {
            using (SchoolEntities cnn = new SchoolEntities())
            {
                var oGrade = cnn.Grade.Find(id);
                cnn.Grade.Remove(oGrade);
                cnn.SaveChanges();

            }

            return Redirect("~/grado/");
        }

    }
}