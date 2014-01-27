﻿using RESTDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTDemo.Controllers
{
    public class DemoController : Controller
    {
        // GET: /Demo/
        private static List<StockQuote> stockList = new List<StockQuote>();
        
        public ActionResult Index()
        {
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
                return PartialView("stockList", model);
            }

            return View("Index", model);
            
        }

        [HttpDelete]
        public string Remove(string symbol)
        {
            foreach (StockQuote stock in stockList.ToList())
            {
                if (stock.Symbol == symbol)
                {
                    stockList.Remove(stock);                
                }
            }

            var model = from r in stockList
                        orderby r.Symbol
                        select r;

            return "ok";
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
