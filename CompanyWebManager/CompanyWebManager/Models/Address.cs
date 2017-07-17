using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Address
    {
        #region Properties
        public int ID { get; set; }

        [Display(Name = "Ulica i numer domu/mieszkania")]
        public string Street { get; set; }

        [Display(Name = "Miejscowosc")]
        public string Town { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        [Display(Name = "Wojewodztwo")]
        public int? VoivodeshipID { get; set; }

        [Display(Name = "Kraj")]
        public int CountryID { get; set; }

        public Voivodeship Voivodeship { get; set; }
        public Country Country { get; set; }

        #endregion
    }
}
