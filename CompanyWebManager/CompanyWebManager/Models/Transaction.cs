using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Transaction
    {
        public int ID { get; set; }

        public int TransactionID { get; set; }

        [Display(Name = "Typ")]
        public string Type { get; set; }

        public int ProductID { get; set; }

        [Display(Name = "Cena Netto")]
        public decimal ProductNetPrice { get; set; }

        [Display(Name = "Cena Brutto")]
        public decimal ProductGrossPrice { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }
    }
}
