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

            return View("Index", stock);
        }

        [HttpGet]
        public ActionResult Refresh()
        {
            //This is not the most efficient way of doing this
            foreach (StockQuote stock in stockList.ToList())
            {
                string symbol = stock.Symbol;

                StockQuote rstock = (from r in stockList
                             where r.Symbol == symbol
                             select r).FirstOrDefault();

                stockList.Remove(rstock);
                stockList.Add(StockQuoteApi.GetStockQuote(stock.Symbol));
            }

            var model = from r in stockList
                        orderby r.Symbol
                        select r;


            if (Request.IsAjaxRequest())
            {
                return PartialView("_stocks", model);
            }

            return View("Index", model);
            
        }

        [HttpDelete]
        public ActionResult Reset()
        {
            stockList.Clear();

            //var model = from s in stockList
            //            select s;

            return RedirectToAction("Index");
        }

 
    }
}
