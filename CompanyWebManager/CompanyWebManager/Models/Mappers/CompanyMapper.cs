using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Models.ViewModels;

namespace CompanyWebManager.Models.Mappers
{
    public static class CompanyMapper
    {
        public static Company MapViewToCompany(CompaniesViewModel companiesViewModel)
        {
            Company company = new Company
            {
                ID = companiesViewModel.ID,
                Name = companiesViewModel.Name,
                Trade = companiesViewModel.Trade,
                CompanyEmail = companiesViewModel.CompanyEmail,
                Street = companiesViewModel.Street,
                Town = companiesViewModel.Town,
                PostalCode = companiesViewModel.PostalCode,
                Voivodeship = companiesViewModel.Voivodeship,
                Country = companiesViewModel.Country,
                ownerID = companiesViewModel.ownerID
            };

            return company;
        }

        public static CompaniesViewModel MapCompanyToView(Company company, ApplicationDb context)
        {
            CompaniesViewModel vModel = new CompaniesViewModel
            {
                ID = company.ID,
                Name = company.Name,
                Trade = company.Trade,
                CompanyEmail = company.CompanyEmail,
                Street = company.Street,
                Town = company.Town,
                PostalCode = company.PostalCode,
                Voivodeship = company.Voivodeship,
                Country = company.Country,
                ownerID = company.ownerID,
                VoivodeshipName = context.Voivodeships.Where(v => v.ID == company.Voivodeship).Select(v => v.Name).First(),
                CountryName = context.Countries.Where(v => v.ID == company.Country).Select(v => v.Name).First()
            };

            return vModel;
        }

        public static CompaniesListViewModel MapCompaniesListToView(IQueryable<Company> companies, ApplicationDb context)
        {
            CompaniesListViewModel vModel = new CompaniesListViewModel();

            vModel.Companies = companies.Select(c => new CompaniesViewModel()
            {
                ID = c.ID,
                Name = c.Name,
                Trade = c.Trade,
                CompanyEmail = c.CompanyEmail,
                Street = c.Street,
                Town = c.Town,
                PostalCode = c.PostalCode,
                ownerID = c.ownerID,
                VoivodeshipName = context.Voivodeships.Where(v => v.ID == c.Voivodeship).Select(v => v.Name).First(),
                CountryName = context.Countries.Where(v => v.ID == c.Country).Select(v => v.Name).First()
            }).ToList();

            return vModel;
        }
    }
}
