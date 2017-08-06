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

        [Display(Name = "Kopia - CC")]
        public string CarbonCopy { get; set; }

        [Display(Name = "Kopia ukryta - BCC")]
        public string BlindCarbonCopy { get; set; }

        [Display(Name = "Temat")]
        public string Subject { get; set; }

        [Display(Name = "Treść")]
        public string Message { get; set; }

        [Display(Name = "Treść")]
        public string MessageToDisplay => Message.Length > 50 ? Message.Substring(0, 50) + "..." : Message;

        [Display(Name = "Data odbioru")]
        public DateTime ReceivedTime { get; set; }

        public bool? Success{ get; set; }

        public string Uid { get; set; }

        public bool? Saved { get; set; }

        public int OwnerID { get; set; }

        public Owner Owner { get; set; }

        #endregion
    }
}
