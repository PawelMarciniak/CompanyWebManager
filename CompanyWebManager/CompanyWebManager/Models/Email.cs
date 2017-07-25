using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Odbiorca")]
        public string Receiver { get; set; }

        [Display(Name = "Kopia_cc")]
        public string CarbonCopy { get; set; }

        [Display(Name = "Kopia_bcc")]
        public string BlindCarbonCopy { get; set; }

        [Display(Name = "Temat")]
        public string Subject { get; set; }

        [Display(Name = "Treść")]
        public string Message { get; set; }

        [Display(Name = "Data odbioru")]
        public DateTime ReceivedTime { get; set; }

        public int OwnerID { get; set; }

        public Owner Owner { get; set; }

        #endregion
    }
}
