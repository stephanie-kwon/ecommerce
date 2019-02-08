using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class LoginUser 
    {
        [Required]
        public string login_Email {get;set;}

        [Required]
        public string login_Password {get;set;}

    }
}