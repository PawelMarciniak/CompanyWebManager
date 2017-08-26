using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.DataModels
{
    public class ProductMaxAvaiability
    {
        public int ProductID { get; set; }
        public int MaxAvaiability { get; set; }
        public int Units { get; set; }
        public string Message { get; set; }
    }
}
