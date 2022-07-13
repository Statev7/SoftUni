namespace FastFood.Core.MappingConfiguration
{
    using System.Linq;

    using AutoMapper;

    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, conf => conf.MapFrom(c => c.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            //Employees
            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>();

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(
                revm => revm.PositionId, 
                conf => conf.MapFrom(p => p.Id));

            //Items

            this.CreateMap<CreateItemInputModel, Item>();
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(
                civm => civm.CategoryId,
                conf => conf.MapFrom(c => c.Id));

            this.CreateMap<Item, ItemsAllViewModels>();

            //Orders

            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<Order, OrderAllViewModel>();
        }
    }
}
