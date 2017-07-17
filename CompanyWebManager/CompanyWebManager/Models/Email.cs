using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Email
    {
        #region Properties
        public int ID { get; set; }

        [Display(Name = "Nadawca")]
        public string Sender { get; set; }

        [Display(Name = "Temat")]
        public string Title { get; set; }

        [Display(Name = "Treść")]
        public int Message { get; set; }

        [Display(Name = "Data odbioru")]
        public int ReceivedTime { get; set; }
        #endregion
    }
}
