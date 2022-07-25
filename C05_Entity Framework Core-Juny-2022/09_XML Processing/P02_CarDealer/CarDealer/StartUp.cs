namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CarDealer.Data;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    public class StartUp
    {
        private const string SUCCESSFULY_IMPORT_MESSAGE = "Successfully imported {0}";

        private static IMapper mapper;

        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();
            //string xml = File.ReadAllText(@"../../../Datasets/sales.xml");
            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            GenerateMapper();

            XmlRootAttribute root = new XmlRootAttribute("Suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDTO[]), root);

            using StringReader reader = new StringReader(inputXml);
            ImportSupplierDTO[] importSupplierDTOs = (ImportSupplierDTO[])serializer.Deserialize(reader);

            IList<Supplier> suppliers = new List<Supplier>();
            foreach (var supplierDTO in importSupplierDTOs)
            {
                Supplier supplier = mapper.Map<Supplier>(supplierDTO);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULY_IMPORT_MESSAGE, suppliers.Count);
            return message;
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            GenerateMapper();

            ExportSupplierIdDTO[] suppliers = context
                .Suppliers
                .ProjectTo<ExportSupplierIdDTO>(mapper.ConfigurationProvider)
                .ToArray();

            ImportPartDTO[] importPartDTOs = Deserializer<ImportPartDTO[]>("Parts", inputXml);
            IList<Part> parts = new List<Part>(); 

            foreach (var partDTO in importPartDTOs)
            {
                bool isValid = suppliers.Any(s => s.Id == partDTO.SupplierId);
                if (isValid)
                {
                    Part part = mapper.Map<Part>(partDTO);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULY_IMPORT_MESSAGE, parts.Count);
            return message;
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            GenerateMapper();

            ExportPartIdDTO[] partIds = context
                .Parts
                .ProjectTo<ExportPartIdDTO>(mapper.ConfigurationProvider)
                .ToArray();

            ImportCarDTO[] importCarDTOs = Deserializer<ImportCarDTO[]>("Cars", inputXml);
            IList<Car> cars = new List<Car>();  

            foreach (var importCar in importCarDTOs)
            {
                Car car = mapper.Map<Car>(importCar);

                foreach (var part in importCar.Parts.Distinct())
                {
                    bool isValid = partIds.Any(p => p.Id == part.PartId && 
                                               !car.PartCars.Any(pc => pc.PartId == part.PartId));

                    if (isValid)
                    {
                        PartCar partCar = new PartCar()
                        {
                            CarId = car.Id,
                            PartId = part.PartId,
                        };

                        car.PartCars.Add(partCar);
                    }
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULY_IMPORT_MESSAGE, cars.Count);
            return message;
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            GenerateMapper();

            ImportCustomerDTO[] importCustomerDTOs = Deserializer<ImportCustomerDTO[]>("Customers", inputXml);
            IList<Customer> customers = new List<Customer>();

            foreach (var customerDTO in importCustomerDTOs)
            {
                Customer customer = mapper.Map<Customer>(customerDTO);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULY_IMPORT_MESSAGE, customers.Count);
            return message;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            GenerateMapper();

            ExportCarIdDTO[] carIds = context
                .Cars
                .ProjectTo<ExportCarIdDTO>(mapper.ConfigurationProvider)
                .ToArray();

            ImportSaleDTO[] importSaleDTOs = Deserializer<ImportSaleDTO[]>("Sales", inputXml);
            IList<Sale> sales = new List<Sale>();

            foreach (var importSale in importSaleDTOs)
            {
                bool isCarIdValid = carIds.Any(c => c.Id == importSale.CarId);
                if (isCarIdValid)
                {
                    Sale sale = mapper.Map<Sale>(importSale);
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            string message = string.Format(SUCCESSFULY_IMPORT_MESSAGE, sales.Count);
            return message;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            GenerateMapper();

            ExportCarWithDistanceDTO[] cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .ProjectTo<ExportCarWithDistanceDTO>(mapper.ConfigurationProvider)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            string result = Serializer(cars, "cars");
            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            GenerateMapper();

            ExportBmwCarDTO[] cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .ProjectTo<ExportBmwCarDTO>(mapper.ConfigurationProvider)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            string result = Serializer(cars, "cars");
            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            GenerateMapper();

            ExportLocalSupplierDTO[] suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportLocalSupplierDTO>(mapper.ConfigurationProvider)
                .ToArray();

            string result = Serializer(suppliers, "suppliers");
            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarWithPartsDTO[] cars = context
                .Cars
                .Select(c => new ExportCarWithPartsDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    PartCars = c.PartCars.Select(pc => new ExportPartDTO
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            string result = Serializer(cars, "cars");
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            GenerateMapper();

            ExportCustomerTotalSalesDTO[] customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .ProjectTo<ExportCustomerTotalSalesDTO>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            string result = Serializer(customers, "customers");
            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new ExportSaleWithDiscountDTO
                {
                    Car = new ExportCarForSaleDTO
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(ps => ps.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(ps => ps.Part.Price) -
                                        (s.Car.PartCars.Sum(ps => ps.Part.Price) * (s.Discount / 100))
                })
                .ToArray();

            string result = Serializer(sales, "sales");
            return result;
        }

        private static void GenerateMapper()
        {
            MapperConfiguration configuration = new MapperConfiguration(conf =>
            {
                conf.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(configuration);
        }

        private static T Deserializer<T>(string rootTag, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootTag);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            T dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = (T)serializer.Deserialize(reader);
            }

            return dtos;
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
    }
}