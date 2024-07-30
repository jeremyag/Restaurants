﻿using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address,
                opt => opt.MapFrom(src => new Address()
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address != null ? src.Address.City : null))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address != null ? src.Address.Street : null))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address != null ? src.Address.PostalCode : null))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
    }
}
