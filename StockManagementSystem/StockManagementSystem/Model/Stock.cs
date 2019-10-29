using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
    public class Stock
    {

        public string Code { get; set; }
        public  string Product { get; set; }
        public  string Category { get; set; }
        public  int ReorderLevel { get; set; }
        public string ExpiredDate { get; set; }
        public  string ExpiredQuantity { get; set; }
        public double OpeningBalance { get; set; }
        public double In { get; set; }
        public double Out { get; set; }
        public double ClosingBalance { get; set; }


    }
}
