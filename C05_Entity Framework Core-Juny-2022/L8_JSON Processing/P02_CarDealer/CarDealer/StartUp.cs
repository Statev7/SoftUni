namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using Data;
    using Models;
    using CarDealer.DTO;
    using AutoMapper.QueryableExtensions;
    using System.Globalization;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        private const string SUCCESFULLY_IMPORT_MESSAGE = "Successfully imported {0}.";

        public static void Main()
        {
            var dbContext = new CarDealerContext();

            //dbContext.Database.Migrate();
            //var inputJson = File.ReadAllText(@"./../../../Datasets/sales.json");
            Console.WriteLine(GetTotalSalesByCustomer(dbContext));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return string.Format(SUCCESFULLY_IMPORT_MESSAGE, suppliers.Count);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliers = context.Suppliers
                        .ProjectTo<SupplierIdDTO>(GetMapperConfiguration())
                        .ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .OrderByDescending(x => x.SupplierId)
                .ToList()
                .Where(x => IsSupplierExist(x, suppliers))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return string.Format(SUCCESFULLY_IMPORT_MESSAGE, parts.Count);
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var conf = GetMapperConfiguration();
            var mapper = conf.CreateMapper();

            var jsonCars = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);
            var parts = context.Parts
                .Select(x => x.Id)
                .ToList();

            var cars = new List<Car>();

            foreach (var car in jsonCars)
            {
                var carToAdd = mapper.Map<Car>(car);

                foreach (var partId in car.PartsId.Distinct())
                {
                    if (parts.Contains(partId))
                    {
                        var partCar = new PartCar
                        {
                            CarId = carToAdd.Id,
                            PartId = partId
                        };

                        carToAdd.PartCars.Add(partCar);
                    }
                }

                cars.Add(carToAdd);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return string.Format(SUCCESFULLY_IMPORT_MESSAGE, jsonCars.Count);
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return string.Format(SUCCESFULLY_IMPORT_MESSAGE, customers.Count);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return string.Format(SUCCESFULLY_IMPORT_MESSAGE, sales.Count);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, GetJsonSettings());
            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make.ToLower() == "toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var result = JsonConvert.SerializeObject(cars, GetJsonSettings());
            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(suppliers, GetJsonSettings());
            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = $"{pc.Part.Price:F2}"
                    })
                }).ToList();

            var result = JsonConvert.SerializeObject(cars, GetJsonSettings());
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .ProjectTo<CustomerSalesDTO>(GetMapperConfiguration())
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var result = JsonConvert.SerializeObject(customers, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Select(pc => pc.Part.Price).Sum():F2}",
                    priceWithDiscount = $"{s.Car.PartCars.Select(pc => pc.Part.Price).Sum() - ((s.Car.PartCars.Select(pc => pc.Part.Price).Sum()) * s.Discount / 100):F2}"
                })
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(sales, GetJsonSettings());
            return result;
        }

        private static bool IsSupplierExist(Part part, List<SupplierIdDTO> suppliers) 
            => suppliers.Any(x => x.Id == part.SupplierId);

        private static MapperConfiguration GetMapperConfiguration()
        {
            MapperConfiguration configuration = new MapperConfiguration(conf =>
            {
                conf.AddProfile<CarDealerProfile>();
            });

            return configuration;
        }

        private static JsonSerializerSettings GetJsonSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

    }
}