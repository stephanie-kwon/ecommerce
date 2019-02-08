using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    public class Item
    {
        [Key]
        public int itemId {get;set;}
        
        [Required]
        public string itemName {get;set;}

        [Required]
        public string itemCategory {get;set;}

        [Required]
        public decimal itemPrice {get;set;}

        [Required]
        public string itemDesc {get;set;}

        [Required]
        public string itemImage {get;set;}

        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public List<Bought> boughts {get;set;}

    }
}