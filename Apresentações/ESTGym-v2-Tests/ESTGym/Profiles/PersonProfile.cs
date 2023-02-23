using AutoMapper;
using ESTGym.Models;
using ESTGym.ViewModels;

namespace ESTGym.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonBmiViewModel >();
        }
    }
}
