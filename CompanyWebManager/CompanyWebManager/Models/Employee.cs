﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models
{
    public class Employee
    {
        #region Properties

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
        public int? Voivodeship { get; set; }
        public int Country { get; set; }
        public int ownerID { get; set; }


        #endregion
    }
}
