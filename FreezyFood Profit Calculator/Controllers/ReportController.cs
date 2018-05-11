using FreezyFood_Profit_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreezyFood_Profit_Calculator.Controllers
{
    public class ReportController : Controller
    {
        private ProfitDbContext db = new ProfitDbContext();

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProfitNaDan()
        {
            Unit u = new Unit();
            return View(u);
        }

        public ActionResult ProfitNaDanReturn([Bind(Include = "DateOfPurchase")] Unit unit)
        {
            var units = db.Units.Where(p => p.DateOfPurchase == unit.DateOfPurchase).ToList();
            decimal profitSum = 0.0m;
            foreach (var item in units)
            {
                profitSum += item.CalculatedProfit;
            }
            ViewBag.Profit = profitSum;
            return View(units);
        }

        public ActionResult UkupanProfit()
        {
            var units = db.Units.ToList();
            decimal profitSum = 0.00m;
            foreach (var item in units)
            {
                profitSum += item.CalculatedProfit;
            }
            ViewBag.Profit = profitSum;
            return View(units);
        }

        //public ActionResult UkupanProfitReturn([Bind(Include = "DateOfPurchase")] Unit unit)
        //{
        //    var units = db.Units.ToList();
        //    decimal profitSum = 0.00m;
        //    foreach (var item in units)
        //    {
        //        profitSum += item.CalculatedProfit;
        //    }
        //    ViewBag.Profit = profitSum;
        //    return View(units);
        //}
    }
}