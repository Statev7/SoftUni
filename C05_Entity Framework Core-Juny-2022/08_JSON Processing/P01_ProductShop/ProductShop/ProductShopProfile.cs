namespace ProductShop
{
    using System;
    using System.Linq;

    using AutoMapper;

    using ProductShop.DTO;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Products
            this.CreateMap<Product, ProductInRangeDTO>()
                .ForMember(x => x.Seller, y => y.MapFrom(p => p.Seller.FirstName + " " + p.Seller.LastName));

            this.CreateMap<Product, SoldProductDTO>();
            this.CreateMap<Product, UserSoldProductsDTO>();

            //Categories
            this.CreateMap<Category, CategoryDTO>()
                .ForMember(x =>  x.AveragePrice,
                y => y.MapFrom(c => $"{c.CategoryProducts.Select(cp => cp.Product.Price).Average():F2}"))
                .ForMember(x => x.TotalRevenue,
                y => y.MapFrom(c => $"{c.CategoryProducts.Select(cp => cp.Product.Price).Sum():F2}"));
            
        }
    }
}
