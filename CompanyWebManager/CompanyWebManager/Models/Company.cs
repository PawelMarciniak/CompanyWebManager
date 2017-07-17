using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int OwnerID { get; set; }
        public int AddressID { get; set; }

        public Owner Owner { get; set; }
        public Address Address { get; set; }

        #endregion
    }   
}
