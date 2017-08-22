using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Models;

namespace CompanyWebManager.Helpers
{
    public class TransactionHelper
    {
        public void SaveTransaction(TransactionData transactionData, ApplicationDb context)
        {
            TransactionDescription transDesc = new TransactionDescription();

            transDesc.Type = transactionData.Type;
            transDesc.Description = transactionData.Description;
            transDesc.Date = DateTime.Now;

            context.Add(transDesc);
            context.SaveChanges();

            var id = transDesc.ID;

            foreach (Product product in transactionData.Products)
            {
                Transaction trans = new Transaction();

                trans.TransactionDescriptionID = id;
                trans.ProductID = product.ID;
                trans.UnitNetPrice = product.NetPrice;
                trans.UnitGrossPrice = product.GrossPrice;
                trans.ProductUnits = product.Units;
                trans.GrossPrice = product.GrossPrice * product.Units;
                trans.NetPrice = product.NetPrice * product.Units;

                context.Add(trans);
                context.SaveChanges();
            }

            UpdateProductUnits(transactionData, context);
        }

        public void UpdateProductUnits(TransactionData data, ApplicationDb context)
        {
            foreach (Product product in data.Products)
            {
                var quantity = context.Product.Where(p => p.ID == product.ID).Select(p => p.Quantity).First();
                int newQuaintity = data.Type == 1 ? quantity + product.Quantity : quantity - product.Quantity;

                product.Units = newQuaintity;

                context.Product.Attach(product);
                context.Entry(product).Property(u => u.Units).IsModified = true;
                context.SaveChanges();
            }
        }

    }
}
