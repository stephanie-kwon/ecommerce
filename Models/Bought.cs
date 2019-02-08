using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Models
{
    public class Bought
    {
        [Key]
        public string boughtId { get; set; }

        public int userId {get;set;}
        public User users {get;set;}

        public int itemId {get;set;}
        public Item items {get;set;}



    }
}
