using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.ViewModels
{
    public class ProductsOfTransaction
    {
        public TransactionDescription TransactionDescription { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Product Product { get; set; }
    }
}
