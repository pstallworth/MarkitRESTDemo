using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;

namespace RESTDemo.Models
{
    public class StockQuoteApi
    {
        public static string GetStockData(string quote)
        {
            var url = "http://dev.markitondemand.com/Api/v2/Quote/json?symbol=" + quote;

            var syncClient = new WebClient();
            var data = syncClient.DownloadString(url);
            return data;
        }

        public static StockQuote GetStockQuote(string symbol)
        {
            var quoteData = GetStockData(symbol);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(StockQuote));
            using (var ms = new System.IO.MemoryStream(Encoding.Unicode.GetBytes(quoteData)))
            {
                var quote = (StockQuote)serializer.ReadObject(ms);
                return quote;
            }

        }
    }
}