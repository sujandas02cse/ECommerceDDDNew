using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;private set; }
        [Required, MaxLength(200)]
        public string Name { get; private set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; private set; }

        [Required, MaxLength(200)]
        public string Description { get; private set; } = null!;

        public int StockQuantity { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

        private Product() { }
        public Product(string name, decimal price, string description, int stockQuantity)
        {
            Name = name;
            Price = price;
            Description = description;
            StockQuantity = stockQuantity;
        }

        public void ChangePrice(decimal newPrice)
        {
            if(newPrice<=0)
                throw new ArgumentException("Price must be a positive value.");
            Price = newPrice;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be a positive value.");
            if (quantity > StockQuantity)
                throw new InvalidOperationException("Not enough stock available.");
            StockQuantity -= quantity;
        }


    }
}
