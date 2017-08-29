using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Models.ViewModels;

namespace CompanyWebManager.Models.Mappers
{
    public static class ProductMapper
    {
        public static Product MapViewToProduct(ProductsViewModel productsViewModel)
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

        public static ProductsViewModel MapProductToView(Product product)
        {
            ProductsViewModel vModel = new ProductsViewModel
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                NetPrice = product.NetPrice,
                GrossPrice = product.GrossPrice,
                Quantity = product.Quantity,
                CompanyID = product.CompanyID,
                ownerID = product.ownerID
            };

            return vModel;
        }

        public static ProductsListViewModel MapProductsListToView(IQueryable<Product> products)
        {
            ProductsListViewModel vModel = new ProductsListViewModel();

            vModel.Products = products.Select(p => new ProductsViewModel()
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description,
                NetPrice = p.NetPrice,
                GrossPrice = p.GrossPrice,
                Quantity = p.Quantity,
                CompanyID = p.CompanyID,
                ownerID = p.ownerID
            }).ToList();

            return vModel;
        }
    }
}
