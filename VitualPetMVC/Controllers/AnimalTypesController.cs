using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VitualPetMVC.Models;

namespace VitualPetMVC.Controllers
{
    public class AnimalTypesController : Controller
    {
        private VirtualPetMVCEntities db = new VirtualPetMVCEntities();

        // GET: AnimalTypes
        public ActionResult Index()
        {
            return View(db.AnimalTypes.ToList());
        }

        // GET: AnimalTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalTypes.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // GET: AnimalTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeID,PetType,TypeImage,AltTypeImage")] AnimalType animalType)
        {
            if (ModelState.IsValid)
            {
                db.AnimalTypes.Add(animalType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animalType);
        }

        // GET: AnimalTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalTypes.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // POST: AnimalTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeID,PetType,TypeImage,AltTypeImage")] AnimalType animalType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animalType);
        }

        // GET: AnimalTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalTypes.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // POST: AnimalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalType animalType = db.AnimalTypes.Find(id);
            db.AnimalTypes.Remove(animalType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
