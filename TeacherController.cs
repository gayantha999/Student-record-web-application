using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/Index
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.TeacherTables.ToList());
            }
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.TeacherTables.Where(x => x.TID == id).FirstOrDefault());
            }
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(TeacherTable details)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.TeacherTables.Add(details);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.TeacherTables.Where(x => x.TID == id).FirstOrDefault());
            }
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TeacherTable details)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(details).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.TeacherTables.Where(x => x.TID == id).FirstOrDefault());
            }
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels dbModel = new DbModels())
                {
                    TeacherTable teacherTable = dbModel.TeacherTables.Where(x => x.TID == id).FirstOrDefault();
                    dbModel.TeacherTables.Remove(teacherTable);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
