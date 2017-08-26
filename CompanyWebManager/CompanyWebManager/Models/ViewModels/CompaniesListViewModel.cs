using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.ViewModels
{
    public class CompaniesListViewModel
    {
        public List<CompaniesViewModel> Companies { get; set; }
        public CompaniesViewModel Headers { get; set; }

        public CompaniesListViewModel()
        {
            Companies = new List<CompaniesViewModel>();
            Headers = new CompaniesViewModel();
        }
    }
}
