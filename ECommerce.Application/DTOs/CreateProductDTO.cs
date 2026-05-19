using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Application.DTOs
{
    public class CreateProductDTO
    {
        [Required,MaxLength(200)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(0.01,double.MaxValue)]
        public decimal price { get; set; }

        [Range(0,int.MaxValue)]
        public  int  StockQuantity { get; set; }
    }
}
