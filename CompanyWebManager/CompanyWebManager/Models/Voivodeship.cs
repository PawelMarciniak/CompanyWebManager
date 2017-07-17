using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Voivodeship
    {
        public int ID { get; set; }

        [Display(Name = "Wojewodztwo")]
        public string Name { get; set; }
    }
}
