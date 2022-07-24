namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using ProductShop.Data;
    using ProductShop.DTO;
    using ProductShop.Models;

    public class StartUp
    {
        private const string SUCCESSFULY_IMPORT_MESSAGE = "Successfully imported {0}";

        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.Migrate();

            //string inputJson = File.ReadAllText(@"./../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(dbContext, inputJson));

            Console.WriteLine(GetUsersWithProducts(dbContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();

            string result = string.Format(SUCCESSFULY_IMPORT_MESSAGE, users.Count);
            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            string result = string.Format(SUCCESSFULY_IMPORT_MESSAGE, products.Count);
            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            string result = string.Format(SUCCESSFULY_IMPORT_MESSAGE, categories.Count);
            return result; 
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            string result = string.Format(SUCCESSFULY_IMPORT_MESSAGE, categoryProducts.Count);
            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ProductInRangeDTO>(GetMapperConfiguration())
                .ToList();

            var result = FormatResult(products);
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .ProjectTo<UserSoldProductsDTO>(GetMapperConfiguration())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            var result = FormatResult(users);
            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .ProjectTo<CategoryDTO>(GetMapperConfiguration())
                .ToList();

            var result = FormatResult(categories);
            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
               .Include(x => x.ProductsSold)
               .ToList()
               .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
               .Select(x => new
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Age = x.Age,
                   SoldProducts = new
                   {
                       Count = x.ProductsSold.Where(p => p.BuyerId != null).Count(),
                       Products = x.ProductsSold.Where(p => p.BuyerId != null).Select(p => new
                       {
                           Name = p.Name,
                           Price = p.Price
                       })
                       .ToList()
                   }
               })
               .OrderByDescending(x => x.SoldProducts.Count)
               .ToList();

            var result = new
            {
                UsersCount = users.Count(),
                Users = users
            };

            var resultAsJson = JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            });

            return resultAsJson;
        }

        private static string FormatResult(Object obj)
        {
            var resultAsJson = JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented,
            });

            return resultAsJson;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }
    }
}