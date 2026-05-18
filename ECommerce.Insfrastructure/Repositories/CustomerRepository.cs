using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Insfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Insfrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public CustomerRepository(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Customer customer)
        {
           await _dbContext.Customers.AddAsync(customer);
           await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _dbContext.Customers.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
