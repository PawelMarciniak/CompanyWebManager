using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Models.ViewModels;

namespace CompanyWebManager.Models.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee MapViewToEmployee(EmployeesViewModel employeesViewModel)
        {
            Employee employee = new Employee
            {
                ID = employeesViewModel.ID,
                FirstName = employeesViewModel.FirstName,
                LastName = employeesViewModel.LastName,
                Email = employeesViewModel.Email,
                PhoneNumber = employeesViewModel.PhoneNumber,
                Position = employeesViewModel.Position,
                Salary = employeesViewModel.Salary,
                Street = employeesViewModel.Street,
                Town = employeesViewModel.Town,
                PostalCode = employeesViewModel.PostalCode,
                Voivodeship = employeesViewModel.Voivodeship,
                Country = employeesViewModel.Country,
                ownerID = employeesViewModel.ownerID
            };

            return employee;
        }

        public static EmployeesViewModel MapEmployeeToView(Employee employee, ApplicationDb context)
        {
            EmployeesViewModel vModel = new EmployeesViewModel
            {
                ID = employee.ID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Position = employee.Position,
                Salary = employee.Salary,
                Street = employee.Street,
                Town = employee.Town,
                PostalCode = employee.PostalCode,
                Voivodeship = employee.Voivodeship,
                Country = employee.Country,
                ownerID = employee.ownerID,
                VoivodeshipName = context.Voivodeships.Where(v => v.ID == employee.Voivodeship).Select(v => v.Name).First(),
                CountryName = context.Countries.Where(v => v.ID == employee.Country).Select(v => v.Name).First()
            };

            return vModel;
        }

        public static EmployeesListViewModel MapEmployeesListToView(IQueryable<Employee> employees, ApplicationDb context)
        {
            EmployeesListViewModel vModel = new EmployeesListViewModel();

            vModel.Employees = employees.Select(e => new EmployeesViewModel()
            {
                ID = e.ID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Position = e.Position,
                Salary = e.Salary,
                Street = e.Street,
                Town = e.Town,
                PostalCode = e.PostalCode,
                ownerID = e.ownerID,
                VoivodeshipName = context.Voivodeships.Where(v => v.ID == e.Voivodeship).Select(v => v.Name).First(),
                CountryName = context.Countries.Where(v => v.ID == e.Country).Select(v => v.Name).First()
            }).ToList();

            return vModel;
        }
    }
}
