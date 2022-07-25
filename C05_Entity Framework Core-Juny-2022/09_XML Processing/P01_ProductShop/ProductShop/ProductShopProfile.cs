namespace ProductShop
{
    using System.Linq;

    using AutoMapper;

    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Products
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<Product, ExportProductIdDTO>();
            this.CreateMap<Product, ExportProductInRageDTO>()
                .ForMember(d => d.Buyer, conf => conf.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));
            this.CreateMap<Product, SoldProductDTO>();

            //Categories
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<Category, ExportCategoryIdDTO>();
            this.CreateMap<Category, ExportCategoryWithProductsDTO>()
                .ForMember(d => d.Count, conf => conf.MapFrom(s => s.CategoryProducts.Count()))
                .ForMember(d => d.AveragePrice, conf => conf.MapFrom(s => s.CategoryProducts.Select(cp => cp.Product.Price).Average()))
                .ForMember(d => d.TotalRevenue, conf => conf.MapFrom(s => s.CategoryProducts.Select(cp => cp.Product.Price).Sum()));

            //CategoryProduct
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            //Users
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<User, ExportUserWithSoldProductsDTO>()
                .ForMember(d => d.SoldProducts, conf => conf.MapFrom(s => s.ProductsSold));
            this.CreateMap<User, SoldProductsDTO>()
                .ForMember(d => d.Count, conf => conf.MapFrom(s => s.ProductsSold.Count()))
                .ForMember(d => d.Products, conf => conf.MapFrom(s => s.ProductsSold.Select(ps => ps)));
            this.CreateMap<User, ExportUsersWithProductsDTO>()
                .ForMember(d => d.ProductsInfo, conf => conf.MapFrom(s => s.ProductsSold));
        }
    }
}
