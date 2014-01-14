using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTDemo.Models
{
    [DataContract]
    public class StockQuote
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public double LastPrice { get; set; }
        [DataMember]
        public double Change { get; set; }
        [DataMember]
        public double ChangePercent { get; set; }
        [DataMember]
        public string Timestamp { get; set; }
        [DataMember]
        public double MSDate { get; set; }
        [DataMember]
        public long MarketCap { get; set; }
        [DataMember]
        public long Volume { get; set; }
        [DataMember]
        public double ChangeYTD { get; set; }
        [DataMember]
        public double ChangePercentYTD { get; set; }
        [DataMember]
        public double High { get; set; }
        [DataMember]
        public double Low { get; set; }
        [DataMember]
        public double Open { get; set; }
    }
}