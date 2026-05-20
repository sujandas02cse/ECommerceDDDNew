using ECommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Service
{
    public interface IOrderService
    {
        Task<int> PlaceOrderAsync(CreateOrderRequestDTO orderRequest);
        Task<OrderDTO> GetOrderByIdAsync(int orderId);
    }
}
