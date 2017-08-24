using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.Enums;
using CompanyWebManager.Extensions;

namespace CompanyWebManager.Models.ViewModels
{
    public class ProductsOfTransactions
    {
        [Display(Name = "ID Transakcji")]
        public int TransactionDescriptionID { get; set; }

        [Display(Name = "Opis transakcji")]
        public string TransDescDesc { get; set; }

        [Display(Name = "Data transakcji")]
        public DateTime TransDescDate { get; set; }

        [Display(Name = "Typ transakcji")]
        public int Type { get; set; }

        [NotMapped]
        public string TypeDesc => Type == 1 ? TransactionType.Revenue.Description() : TransactionType.Expense.Description();

        public int ID { get; set; }

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

        [Display(Name = "Produkt")]
        public int ProductID { get; set; }

        [Display(Name = "Nazwa produktu")]
        public string ProductName { get; set; }

        public List<ProductsOfTransactions> Transactions { get; set; }
    }
}

