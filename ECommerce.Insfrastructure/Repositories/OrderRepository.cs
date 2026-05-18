using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Insfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Insfrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderRepository(ECommerceDbContext context)
        {
            _context = context;
        }


        public async Task AddAysnc(Order order)
        {
           await _context.Orders.AddAsync(order);
           await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Items) //Eager loading of related entities
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
