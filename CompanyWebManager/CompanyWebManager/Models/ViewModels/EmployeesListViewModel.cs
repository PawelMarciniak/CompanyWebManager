using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.ViewModels
{
    public class EmployeesListViewModel
    {
        public List<EmployeesViewModel> Employees { get; set; }
        public EmployeesViewModel Headers { get; set; }

        public EmployeesListViewModel()
        {
            Employees = new List<EmployeesViewModel>();
            Headers = new EmployeesViewModel();
        }
    }
}
