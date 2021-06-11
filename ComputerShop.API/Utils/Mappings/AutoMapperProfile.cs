using AutoMapper;
using ComputerShop.Data.Contracts;
using ComputerShop.Data.Models;
using ComputerShop.Models.RequestModels;
using ComputerShop.Models.ResponseModels;
using System.Linq;

namespace ComputerShop.API.Utils.Mappings
{
    public class AutoMapperProfile : Profile  
    {  
        public AutoMapperProfile()
        {
            CreateMap<Laptop, LaptopModel>()
                .ForMember(dest => dest.Configurations, opt => opt.MapFrom(src => src.LaptopConfigurations.Select(lc => lc.Configuration).ToList()));

            CreateMap<Laptop, LaptopResponse>()
                .ForMember(dest => dest.Configurations, opt => opt.MapFrom(src => src.LaptopConfigurations.Select(lc => lc.Configuration).ToList()));

            CreateMap<Configuration, ConfigurationModel>()
                .ForMember(dest => dest.ConfigurationTypeName, opt => opt.MapFrom(src => src.ConfigurationType.Name));

            CreateMap<AddLaptopModel, AddLaptopParameter>();
            CreateMap<AddLaptopConfigurationModel, AddConfigurationParameter>();
            CreateMap<AddOrderModel, AddOrderParameter>();
        }
    }  
}
