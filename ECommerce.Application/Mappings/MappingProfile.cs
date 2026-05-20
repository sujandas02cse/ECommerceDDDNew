using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // product mapping
            CreateMap<Product,ProductDTO>();
            CreateMap<CreateProductDTO,ProductDTO>();

            // order mapping
            CreateMap<Order,OrderDTO>();
            CreateMap<OrderItem,OrderItemDTO>();

            // address mapping
            CreateMap<Address,AddressDTO>();

        }
    }
}
