﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string InvoiceNo { get; set; } 
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string ManufacturedDate { get; set; }
        public string ExpireDate { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double MRP { get; set; }
        public string Remarks { get; set; }

    }

}
