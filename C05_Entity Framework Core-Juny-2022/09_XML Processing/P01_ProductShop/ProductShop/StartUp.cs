namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

    public class StartUp
    {
        private const string SUCCESSFULLY_IMPORT_MESSAGE = "Successfully imported {0}";

        private static IMapper mapper;

        public static void Main()
        {
            var dbContext = new ProductShopContext();
            //var xml = File.ReadAllText(@"../../../Datasets/categories-products.xml");

            Console.WriteLine(GetUsersWithProducts(dbContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            GenerateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDTO[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportUserDTO[] usersDTOs = (ImportUserDTO[])serializer.Deserialize(reader);

            IList<User> users = new List<User>();
            foreach (var userDto in usersDTOs)
            {
                User user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULLY_IMPORT_MESSAGE, users.Count);
            return message;
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            GenerateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDTO[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportProductDTO[] importProductDTOs = (ImportProductDTO[])serializer.Deserialize(reader);

            IList<Product> products = new List<Product>();
            foreach (var productDTO in importProductDTOs)
            {
                Product product = mapper.Map<Product>(productDTO);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULLY_IMPORT_MESSAGE, products.Count);
            return message;
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            GenerateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDTO[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);
            ImportCategoryDTO[] importCategoryDTOs = (ImportCategoryDTO[])serializer.Deserialize(stringReader);

            IList<Category> categories = new List<Category>();
            foreach (var categoryDTO in importCategoryDTOs
                                            .Where(x => x.Name != null))
            {
                Category category = mapper.Map<Category>(categoryDTO);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULLY_IMPORT_MESSAGE, categories.Count);
            return message;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            GenerateMapper();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]), xmlRoot);

            IList<ExportProductIdDTO> productIds = context.Products
                .ProjectTo<ExportProductIdDTO>(GetMapperConfiguration())
                .ToList();

            IList<ExportCategoryIdDTO> categoryIds = context.Categories
                .ProjectTo<ExportCategoryIdDTO>(GetMapperConfiguration())
                .ToList();

            using StringReader reader = new StringReader(inputXml);
            ImportCategoryProductDTO[] importCategoryProductDTOs = (ImportCategoryProductDTO[])serializer.Deserialize(reader);

            IList<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            foreach (var importCategoryProductDTO in importCategoryProductDTOs)
            {
                bool isEntityValid = productIds.Any(x => x.Id == importCategoryProductDTO.ProductId) &&
                               categoryIds.Any(x => x.Id == importCategoryProductDTO.CategoryId);

                if (isEntityValid)
                {
                    CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(importCategoryProductDTO);
                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULLY_IMPORT_MESSAGE, categoryProducts.Count);
            return message;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductInRageDTO[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductInRageDTO>(GetMapperConfiguration())
                .Take(10)
                .ToArray();

            string result = Serializer(products, "Products");
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .ProjectTo<ExportUserWithSoldProductsDTO>(GetMapperConfiguration())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            string result = Serializer(users, "Users");
            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoryWithProductsDTO[] categories = context
                .Categories
                .ProjectTo<ExportCategoryWithProductsDTO>(GetMapperConfiguration())
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            string result = Serializer(categories, "Categories");
            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportUsersWithProductsDTO[] users = context.Users
                .ToArray()
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new ExportUsersWithProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    ProductsInfo = new SoldProductsDTO
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(ps => new SoldProductDTO
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                        })
                        .OrderByDescending(ps => ps.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            ExportUsers exportUsers = new ExportUsers
            {
                Count = context.Users.Count(u => u.ProductsSold.Count > 0),
                Users = users
            };

            var result = Serializer(exportUsers, "Users");
            return result;
        }

        private static string Serializer<T>(T dto, string rootTag)
        {
            var sb = new StringBuilder();

            var root = new XmlRootAttribute(rootTag);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = new XmlSerializer(typeof(T), root);

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, dto, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static void GenerateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            MapperConfiguration config = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfile<ProductShopProfile>();
            });

            return config;
        }
    }
}