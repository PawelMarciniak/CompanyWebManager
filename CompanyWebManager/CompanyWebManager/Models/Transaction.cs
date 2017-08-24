using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Transaction
    {
        public int ID { get; set; }

        public int TransactionDescriptionID { get; set; }

        [Display(Name = "Produkt")]
        public int ProductID { get; set; }

        [Display(Name = "Cena Netto za szt")]
        public decimal UnitNetPrice { get; set; }

        [Display(Name = "Cena Brutto za szt")]
        public decimal UnitGrossPrice { get; set; }

        [Display(Name = "Ilosc")]
        public int ProductUnits { get; set; }

        [Display(Name = "Kwota Netto")]
        public decimal NetPrice { get; set; }

        [Display(Name = "Kwota Brutto")]
        public decimal GrossPrice { get; set; }

        //public List<Product> Products { get; set; }
    }
}
