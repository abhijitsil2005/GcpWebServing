using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GcpWebServing.Models
{
    public class Product
    {
        public long Id { get; set; }
        public int sku { get; set; }
        public string name { get; set; }
        public string type { get; set; }
		public double? price { get; set; }
		public string upc { get; set; }
        public List<Category> category { get; set; }
		public double? shipping { get; set; }
        public string description { get; set; }
		public string manufacturer { get; set; }
		public string model { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public string startswith { get; set; }
    }
}
