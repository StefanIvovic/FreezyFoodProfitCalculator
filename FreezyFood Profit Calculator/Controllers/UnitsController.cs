using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FreezyFood_Profit_Calculator.Models;

namespace FreezyFood_Profit_Calculator.Controllers
{
    public class UnitsController : Controller
    {
        private ProfitDbContext db = new ProfitDbContext();

        // GET: Units
        public ActionResult Index()
        {
            var units = db.Units.Include(u => u.Product);
            return View(units.ToList());
        }

        // GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SaleInGrams,ProductId")] Unit unit, string submit)
        {
            if (ModelState.IsValid)
            {
                var proizvod = db.Products.Find(unit.ProductId);
                decimal nabavnaCenaPoGramu = proizvod.PricePerKGBuy / 1000;
                decimal punaNabavnaCena = nabavnaCenaPoGramu * unit.SaleInGrams;

                decimal prodajnaCenaPoGramu = proizvod.PricePerKGSell / 1000;
                decimal punaProdajnaCena = prodajnaCenaPoGramu * unit.SaleInGrams;

                decimal profit = punaProdajnaCena - punaNabavnaCena;
                unit.CalculatedProfit = profit;
                unit.ProductName = proizvod.ProductName;
                db.Units.Add(unit);
                db.SaveChanges();
                if (submit == "Save")
                    return RedirectToAction("Index");
                if (submit == "Save and stay")
                    return RedirectToAction("Create");

            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", unit.ProductId);
            return View(unit);
        }




        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", unit.ProductId);
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SaleInGrams,ProductId")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", unit.ProductId);
            return View(unit);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
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
