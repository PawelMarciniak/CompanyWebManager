using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Models.ViewModels;

namespace CompanyWebManager.Models.Mappers
{
    public static class ClientMapper
    {
        public static Client MapViewToClient(ClientsViewModel clientsViewModel)
        {
            Client client = new Client
            {
                ID = clientsViewModel.ID,
                FirstName = clientsViewModel.FirstName,
                LastName = clientsViewModel.LastName,
                ClientEmail = clientsViewModel.ClientEmail,
                Street = clientsViewModel.Street,
                Town = clientsViewModel.Town,
                PostalCode = clientsViewModel.PostalCode,
                Voivodeship = clientsViewModel.Voivodeship,
                Country = clientsViewModel.Country,
                ownerID = clientsViewModel.ownerID
            };

            return client;
        }

        public static ClientsViewModel MapClientToView(Client client, ApplicationDb context)
        {
            ClientsViewModel vModel = new ClientsViewModel
            {
                ID = client.ID,
                FirstName = client.FirstName,
                LastName = client.LastName,
                ClientEmail = client.ClientEmail,
                Street = client.Street,
                Town = client.Town,
                PostalCode = client.PostalCode,
                Voivodeship = client.Voivodeship,
                VoivodeshipName = context.Voivodeships.Where(v => v.ID == client.Voivodeship).Select(v => v.Name).First(),
                Country = client.Country,
                CountryName = context.Countries.Where(v => v.ID == client.Country).Select(v => v.Name).First(),
                ownerID = client.ownerID
            };

            return vModel;
        }

        public static ClientsListViewModel MapClientsListToView(IQueryable<Client> clients, ApplicationDb context)
        {
            ClientsListViewModel vModel = new ClientsListViewModel();

            vModel.Clients = clients.Select(s => new ClientsViewModel()
            {
                ID = s.ID,
                FirstName = s.FirstName,
                LastName = s.LastName,
                ClientEmail = s.ClientEmail,
                Street = s.Street,
                Town = s.Town,
                PostalCode = s.PostalCode,
                VoivodeshipName = context.Voivodeships.Where(v => v.ID == s.Voivodeship).Select(v => v.Name).First(),
                CountryName = context.Countries.Where(v => v.ID == s.Country).Select(v => v.Name).First(),
                ownerID = s.ownerID
            }).ToList();

            return vModel;
        }
    }
}
