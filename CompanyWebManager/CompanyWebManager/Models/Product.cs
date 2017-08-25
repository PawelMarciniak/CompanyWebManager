using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Product
    {
        #region Properties

        public int ID { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Cena Netto")]
        public decimal NetPrice { get; set; }

        [Display(Name = "Cena Brutto")]
        public decimal GrossPrice { get; set; }

        [Display(Name = "Stan")]
        public int Quantity { get; set; }

        [Display(Name = "Ilosc")]
        [NotMapped]
        public int Units { get; set; }

        public int CompanyID { get; set; }

        public int ownerID { get; set; }


        #endregion
    }
}
