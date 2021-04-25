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
            //user
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>();

            //customer
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, ReadCustomerDto>();

            //roomtype
            CreateMap<RoomTypeCreateDto, RoomType>();
            CreateMap<RoomType,RoomTypeReadDto>();

            //room
            CreateMap<RoomCreateDto, Room>();
            CreateMap<Room,RoomReadDto>();

               //roomstatus
            CreateMap<RoomStatusCreateDto, RoomStatus>();
            CreateMap<RoomStatus,RoomStatusReadDto>();

                   //reservation
            CreateMap<CreateReservationDto, Reservation>();
            CreateMap<Reservation,ReservationReadDto>();



        }

    }
}