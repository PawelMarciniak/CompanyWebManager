using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public List<ProductsViewModel> Products { get; set; }
        public ProductsViewModel Headers { get; set; }

        public ProductsListViewModel()
        {
            Products = new List<ProductsViewModel>();
            Headers = new ProductsViewModel();
        }
    }
}
