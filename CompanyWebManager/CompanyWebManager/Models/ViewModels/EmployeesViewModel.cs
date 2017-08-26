using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.ViewModels
{
    public class EmployeesViewModel
    {
        #region Properties

        public int ID { get; set; }

        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Numer kontaktowy")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Stanowisko")]
        public string Position { get; set; }

        [Display(Name = "Pensja - brutto")]
        public double Salary { get; set; }

        [Display(Name = "Ulica i numer domu/mieszkania")]
        public string Street { get; set; }

        [Display(Name = "Miejscowosc")]
        public string Town { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        [Display(Name = "Wojewodztwo")]
        public int? Voivodeship { get; set; }

        [NotMapped]
        [Display(Name = "Wojewodztwo")]
        public string VoivodeshipName { get; set; }

        [Display(Name = "Kraj")]
        public int Country { get; set; }

        [NotMapped]
        [Display(Name = "Kraj")]
        public string CountryName { get; set; }

        public int ownerID { get; set; }


        #endregion
    }
}
