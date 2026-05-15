using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?>GetByIdAsync(int id);
        Task AddAysnc(Order order);
    }
}
