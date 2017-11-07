﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVCProject.Models;

namespace WardrobeMVCProject.Controllers
{
    public class OutfitsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Accessory).Include(o => o.Bottom).Include(o => o.Sho).Include(o => o.Top);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoriesID", "AccessoriesName");
            ViewBag.BottomsID = new SelectList(db.Bottoms, "BottomsID", "BottomsName");
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoesName");
            ViewBag.TopsID = new SelectList(db.Tops, "TopsID", "TopsName");
            return View();
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitID,OutfitName,AccessoriesID,TopsID,BottomsID,ShoesID")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                db.Outfits.Add(outfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoriesID", "AccessoriesName", outfit.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.Bottoms, "BottomsID", "BottomsName", outfit.BottomsID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoesName", outfit.ShoesID);
            ViewBag.TopsID = new SelectList(db.Tops, "TopsID", "TopsName", outfit.TopsID);
            return View(outfit);
        }

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoriesID", "AccessoriesName", outfit.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.Bottoms, "BottomsID", "BottomsName", outfit.BottomsID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoesName", outfit.ShoesID);
            ViewBag.TopsID = new SelectList(db.Tops, "TopsID", "TopsName", outfit.TopsID);
            return View(outfit);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitID,OutfitName,AccessoriesID,TopsID,BottomsID,ShoesID")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoriesID", "AccessoriesName", outfit.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.Bottoms, "BottomsID", "BottomsName", outfit.BottomsID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoesName", outfit.ShoesID);
            ViewBag.TopsID = new SelectList(db.Tops, "TopsID", "TopsName", outfit.TopsID);
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
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
