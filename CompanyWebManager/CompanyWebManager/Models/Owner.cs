using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Owner
    {
        #region Properties
        public int ID { get; set; }

        [Display(Name = "Imie")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string OwnerEmail { get; set; }
        [Display(Name = "Data utworzenia")]
        public DateTime Created { get; set; }

        public string UserName { get; set; }
        public int AddressID { get; set; }

        public ApplicationUser User { get; set; }
        public Address Address { get; set; }

        public ICollection<Email> Emails { get; set; }

        #endregion   
    }
}
