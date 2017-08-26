using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.ViewModels
{
    public class ClientsListViewModel
    {
        public List<ClientsViewModel> Clients { get; set; }
        public ClientsViewModel Headers { get; set; }

        public ClientsListViewModel()
        {
            Clients = new List<ClientsViewModel>();
            Headers = new ClientsViewModel();
        }
    }
}
