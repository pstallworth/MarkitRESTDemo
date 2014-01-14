using RESTDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTDemo.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/
        private static List<StockQuote> stockList = new List<StockQuote>();
        
        public ActionResult Index()
        {
            //List<StockQuote> stockList = new List<StockQuote>();
            //stockList.Add(StockQuoteApi.GetStockQuote("CSCO"));
            //stockList.Add(StockQuoteApi.GetStockQuote("HP"));
            //stockList.Add(StockQuoteApi.GetStockQuote("P"));
            //stockList.Add(StockQuoteApi.GetStockQuote("IBM"));

            var model = from r in stockList
                        orderby r.Symbol
                        select r;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_stocks", model);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(string symbol)
        {

            StockQuote stock;
            stock = StockQuoteApi.GetStockQuote(symbol);
            stockList.Add(stock);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_stock", stock);
            }

            return PartialView("_stock", "new row");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Demo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Demo/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Demo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Demo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Demo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Demo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
