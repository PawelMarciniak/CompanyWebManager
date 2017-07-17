using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Country
    {
        public int ID { get; set; }

        [Display(Name = "Kod kraju")]
        public string CountryCode { get; set; }

        [Display(Name = "Kraj")]
        public string Name { get; set; }
    }
}
