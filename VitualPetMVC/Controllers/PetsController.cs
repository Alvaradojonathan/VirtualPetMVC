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
    public class PetsController : Controller
    {
        private VirtualPetMVCEntities db = new VirtualPetMVCEntities();

        // GET: Pets
        public ActionResult Index()
        {
            var pets = db.Pets.Include(p => p.AnimalType);
            return View(pets.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.PetType = new SelectList(db.AnimalTypes, "TypeID", "PetType");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,PetName,PetAge,PetType,HungerLevel,ThirstLevel,BoredomLevel,SicknessLevel,WasteLevel")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                Random level = new Random();
                pet.WasteLevel = level.Next(0, 11);
                pet.SicknessLevel = level.Next(0, 31);
                pet.BoredomLevel = level.Next(0, 11);
                pet.ThirstLevel = level.Next(0, 21);
                pet.HungerLevel = level.Next(0, 51);
                pet.PetAge = DateTime.Now;
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PetType = new SelectList(db.AnimalTypes, "TypeID", "PetType", pet.PetType);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetType = new SelectList(db.AnimalTypes, "TypeID", "PetType", pet.PetType);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID,PetName,PetAge,PetType,HungerLevel,ThirstLevel,BoredomLevel,SicknessLevel,WasteLevel")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetType = new SelectList(db.AnimalTypes, "TypeID", "PetType", pet.PetType);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
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
