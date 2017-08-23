using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.Extensions;


namespace CompanyWebManager.Enums
{
    public enum TransactionType : byte
    {
        [Description("Przychod")]
        Revenue = 1,
        [Description("Rozchod")]
        Expense = 2
    }
}
