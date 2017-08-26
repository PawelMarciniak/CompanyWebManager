using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClientEmail { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
        public int Voivodeship { get; set; }
        public int Country { get; set; }
        public int ownerID { get; set; }
    }
}
