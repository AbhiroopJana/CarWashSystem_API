using AutoMapper;
using CarWashApi.DTOs;
using CarWashApi.DTOs.Car;

using CarWashApi.DTOs.UserProfile;
using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Configurations
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateUserDto, UserProfile>().ReverseMap();
            CreateMap<UpdateUserDto, UserProfile>().ReverseMap();
            CreateMap<GetUserDto, UserProfile>().ReverseMap();

            CreateMap<UpdateCarsDto, CarInfo>().ReverseMap();

        }
    }
}
