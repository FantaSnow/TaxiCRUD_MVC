using AutoMapper;
using TaxiCrudCore.Entities;
using TaxiCrut.Infrastructure;
namespace TaxiCrudServer
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Auto, AutoModel>().ReverseMap();
            CreateMap<Auto, AutoCreate>().ReverseMap();
            CreateMap<Auto, AutoUpdate>().ReverseMap();

            CreateMap<City, CityModel>().ReverseMap();
            CreateMap<City, CityCreate>().ReverseMap();
            CreateMap<City, CityUpdate>().ReverseMap();

            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Order, CityCreate>().ReverseMap();
            CreateMap<Order, OrderUpdate>().ReverseMap();

            CreateMap<Road, RoadModel>().ReverseMap();
            CreateMap<Road, RoadCreate>().ReverseMap();
            CreateMap<Road, RoadUpdate>().ReverseMap();

            CreateMap<Status, StatusModel>().ReverseMap();
            CreateMap<Status, StatusCreate>().ReverseMap();
            CreateMap<Status, StatusUpdate>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, UserCreate>().ReverseMap();
            CreateMap<User, UserUpdate>().ReverseMap();
        }
    }
}
