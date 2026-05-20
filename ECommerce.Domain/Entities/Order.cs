using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Domain.Entities
{

    // Joy Sree Rama
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

     
        [Required]
        public int CustomerId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public Address ShippingAddress { get; private set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; private set; }

        public Customer Customer { get; private set; }

        public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();

        private Order() { }

        public Order(int customerId, Address shippingAddress)
        {
            CustomerId = customerId;
            ShippingAddress = shippingAddress;
            OrderDate = DateTime.Now;
        }
        public void AddItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            if (product.StockQuantity < quantity)
                throw new ArgumentException("Insufficient stock available.", nameof(quantity));

            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                Items.Add(new OrderItem(product.Id, product.Name, product.Price, quantity, this));
            }
            product.ReduceStock(quantity);
            CalculateTotalAmount();
        }
        private void CalculateTotalAmount()
        {
            TotalAmount = Items.Sum(i => i.UnitPrice * i.Quantity);
        }
    }
}
