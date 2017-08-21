using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class TransactionData
    {
        [Display(Name = "Typ")]
        public int Type { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
