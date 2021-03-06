﻿using System;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NetPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public int Quantity { get; set; }
        public int CompanyID { get; set; }
        public int ownerID { get; set; }

        #endregion
    }
}
