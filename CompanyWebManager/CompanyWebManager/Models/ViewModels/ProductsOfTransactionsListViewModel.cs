using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.ViewModels
{
    public class ProductsOfTransactionsListViewModel
    {
        public List<ProductsOfTransactionsViewModel> ProductsOfTransactions { get; set; }
        public ProductsOfTransactionsViewModel Headres { get; set; }

        public ProductsOfTransactionsListViewModel()
        {
            ProductsOfTransactions = new List<ProductsOfTransactionsViewModel>();
            Headres = new ProductsOfTransactionsViewModel();
        }
    }
}

