using API.ViewModels;
using AutoMapper;
using Business.Models;

namespace API.Configurations
{
    public  class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Customer, CustomerViewModel>()            
                .ReverseMap()
                .ForMember(o => o.Id, opt => opt.Ignore());

            CreateMap<Customer, Customer>().ForMember(o=> o.Id, opt => opt.Ignore());
        }
    }
}
