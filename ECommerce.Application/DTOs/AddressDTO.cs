using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace ECommerce.Application.DTOs
{
    public class AddressDTO
    {
        [Required, MaxLength(250)]
        public string Street { get; set; } = null!;

        [Required, MaxLength(100)]
        public string City { get; set; } = null!;

        [Required, MaxLength(100)]
        public string State { get; set; } = null!;

        [Required, MaxLength(100)]
        public string PostalCode { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Country { get; set; } = null!;


    }
}
