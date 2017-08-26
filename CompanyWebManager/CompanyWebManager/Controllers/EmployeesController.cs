using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Helpers;
using CompanyWebManager.Models;
using CompanyWebManager.Models.ViewModels;

namespace CompanyWebManager.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDb _context;

        public EmployeesController(ApplicationDb context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                var employees = _context.Employee.Where(s => s.ownerID == HttpContext.Session.GetObjectFromJson<int>("ownerID"));

                return View(MapEmployeesListToView(employees));

                //var applicationDb = _context.Employee;
                //return View(await applicationDb.ToListAsync());
            }
            return RedirectToAction("Login", "Account", new { area = "" });
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(MapEmployeeToView(employee));
        }

        public IActionResult Create()
        {
            PrepareVoivodeshipsAndCountires();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,PhoneNumber,Position,Salary")] EmployeesViewModel employee)
        {
            if (ModelState.IsValid)
            {
                employee.ownerID = HttpContext.Session.GetObjectFromJson<int>("ownerID");
                _context.Add(MapViewToEmployee(employee));
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            PrepareVoivodeshipsAndCountires();
            return View(MapEmployeeToView(employee));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,PhoneNumber,Position,Salary,AddressID")] EmployeesViewModel employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MapViewToEmployee(employee));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(MapEmployeeToView(employee));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.ID == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }

        #region Helpers

        public Employee MapViewToEmployee(EmployeesViewModel employeesViewModel)
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

        public EmployeesViewModel MapEmployeeToView(Employee employee)
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
                VoivodeshipName = _context.Voivodeships.Where(v => v.ID == employee.Voivodeship).Select(v => v.Name).First(),
                CountryName = _context.Countries.Where(v => v.ID == employee.Country).Select(v => v.Name).First()
            };

            return vModel;
        }

        public EmployeesListViewModel MapEmployeesListToView(IQueryable<Employee> employees)
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
                VoivodeshipName = _context.Voivodeships.Where(v => v.ID == e.Voivodeship).Select(v => v.Name).First(),
                CountryName = _context.Countries.Where(v => v.ID == e.Country).Select(v => v.Name).First()
            }).ToList();

            return vModel;
        }

        public void PrepareVoivodeshipsAndCountires()
        {
            List<Voivodeship> voivodeships = new List<Voivodeship>();

            voivodeships = _context.Voivodeships.ToList();
            voivodeships.Insert(0, new Voivodeship { ID = 0, Name = "Select" });
            ViewBag.Voivodeships = voivodeships;

            List<Country> countries = new List<Country>();

            countries = _context.Countries.ToList();
            countries.Insert(0, new Country { ID = 0, Name = "Select" });
            ViewBag.Countries = countries;
        }

        #endregion
    }
}
