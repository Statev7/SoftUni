namespace CarDealer
{
    using System.Linq;

    using AutoMapper;

    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDTO, Supplier>();
            this.CreateMap<Supplier, ExportSupplierIdDTO>();
            this.CreateMap<Supplier, ExportLocalSupplierDTO>()
                .ForMember(d => d.PartsCount, conf => conf.MapFrom(s => s.Parts.Count));

            //Parts
            this.CreateMap<ImportPartDTO, Part>();
            this.CreateMap<Part, ExportPartIdDTO>();

            //Cars
            this.CreateMap<ImportCarDTO, Car>();
            this.CreateMap<Car, ExportCarIdDTO>();
            this.CreateMap<Car, ExportCarWithDistanceDTO>();
            this.CreateMap<Car, ExportBmwCarDTO>();

            //Customer
            this.CreateMap<ImportCustomerDTO, Customer>();
            this.CreateMap<Customer, ExportCustomerTotalSalesDTO>()
                .ForMember(d => d.FullName, conf => conf.MapFrom(s => s.Name))
                .ForMember(d => d.BoughtCars, conf => conf.MapFrom(s => s.Sales.Count))
                .ForMember(d => d.SpentMoney, conf => conf
                .MapFrom(s => 
                    s.Sales.Select(s => s.Car.PartCars
                    .Sum(pc => pc.Part.Price))
                    .Sum()));

            //Sales
            this.CreateMap<ImportSaleDTO, Sale>(); 

        }
    }
}
