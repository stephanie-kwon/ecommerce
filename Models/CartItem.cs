using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Models
{
    public class CartItem
    {
        [Key]
        public string CartItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public int itemId { get; set; }

        public virtual Item Item { get; set; }

    }
}