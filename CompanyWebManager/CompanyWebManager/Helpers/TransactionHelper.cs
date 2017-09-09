using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Models;
using CompanyWebManager.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebManager.Helpers
{
    public class TransactionHelper
    {
        public void SaveTransaction(TransactionData transactionData, ApplicationDb context, int ownerID)
        {
            TransactionDescription transDesc = new TransactionDescription();

            transDesc.Type = transactionData.Type;
            transDesc.Description = transactionData.Description;
            transDesc.Date = DateTime.Now;
            transDesc.ownerID = ownerID;

            context.Add(transDesc);
            context.SaveChanges();

            var id = transDesc.ID;

            foreach (ProductsViewModel product in transactionData.Products)
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
            foreach (ProductsViewModel product in data.Products)
            {
                //var quantity = context.Product.Where(p => p.ID == product.ID).Select(p => p.Quantity).First();
                var tmpProduct = context.Product.FirstOrDefault(p => p.ID == product.ID);
                var quantity = tmpProduct.Quantity;
                int newQuaintity = data.Type == 1 ? quantity + product.Units : quantity - product.Units;

                tmpProduct.Quantity = newQuaintity;

                Product newProduct = MapViewToProduct(product);

                //context.Product.Attach(newProduct);
                context.Entry(tmpProduct).Property(u => u.Quantity).IsModified = true;
                //context.Entry(tmpProduct).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Map

        public Product MapViewToProduct(ProductsViewModel productsViewModel)
        {
            Product product = new Product
            {
                ID = productsViewModel.ID,
                Name = productsViewModel.Name,
                Description = productsViewModel.Description,
                NetPrice = productsViewModel.NetPrice,
                GrossPrice = productsViewModel.GrossPrice,
                Quantity = productsViewModel.Quantity,
                CompanyID = productsViewModel.CompanyID,
                ownerID = productsViewModel.ownerID
            };

            return product;
        }

        #endregion

    }
}
