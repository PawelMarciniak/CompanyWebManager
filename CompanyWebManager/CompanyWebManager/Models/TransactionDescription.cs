using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.Enums;
using CompanyWebManager.Extensions;

namespace CompanyWebManager.Models
{
    public class TransactionDescription
    {
        public int ID { get; set; }

        [Display(Name = "Typ")]
        public int Type { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        public int ownerID { get; set; }

        [NotMapped]
        public string TypeDesc => Type == 1 ? TransactionType.Revenue.Description() : TransactionType.Expense.Description();
    }
}
