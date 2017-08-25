using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.Views
{
    public class ProductsOfTransactions
    {
        public int TransactionDescriptionID { get; set; }
        public string TransDescDesc { get; set; }
        public DateTime TransDescDate { get; set; }
        public int Type { get; set; }
        [Key]
        public int TransactionID { get; set; }
        public decimal UnitNetPrice { get; set; }
        public decimal UnitGrossPrice { get; set; }
        public int ProductUnits { get; set; }
        public decimal NetPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public string ProductName { get; set; }
        public int ownerID { get; set; }
    }
}
