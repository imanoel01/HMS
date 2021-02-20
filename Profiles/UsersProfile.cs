using AutoMapper;
using HMS.Dtos;
using HMS.Model;

namespace HMS.Profiles
{

    public class UsersProfile : Profile
    {


        public UsersProfile()
        {
            // source => target
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>();


            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, ReadCustomerDto>();

            // CreateMap<Customer, ReadUserDto>();

        }

    }
}