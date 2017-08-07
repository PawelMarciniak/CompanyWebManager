using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Company
    {
        #region Properties
        public int ID { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Branza")]
        public string Trade { get; set; }

        [Display(Name = "Email")]
        public string CompanyEmail { get; set; }

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
        public int? VoivodeshipName { get; set; }

        [Display(Name = "Kraj")]
        public int Country { get; set; }

        [NotMapped]
        [Display(Name = "Kraj")]
        public int? CountryName { get; set; }

        public int OwnerID { get; set; }

        #endregion
    }   
}
