// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
// using Ecommerce.Models;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;


// namespace Ecommerce.Controllers
// {
//   public class ShoppingCartAction : IDisposable
//   {
//     public string ShoppingCartId { get; set; }

//     // private YourContext _db = new YourContext();
//     private YourContext dbContext;

//     public const string CartSessionKey = "CartId";

//     public void AddToCart(int id)
//     {
//       // Retrieve the product from the database.           
//       ShoppingCartId = GetCartId();

//       var cartItem = dbContext.ShoppingCartItems.SingleOrDefault(
//           c => c.CartId == ShoppingCartId
//           && c.itemId == id);
//       if (cartItem == null)
//       {
//         // Create a new cart item if no cart item exists.                 
//         cartItem = new CartItem
//         {
//           CartItemId = Guid.NewGuid().ToString(),
//           itemId = id,
//           CartId = ShoppingCartId,
//           Item = dbContext.Items.SingleOrDefault(
//            p => p.itemId == id),
//           Quantity = 1,
//           DateCreated = DateTime.Now
//         };

//         dbContext.ShoppingCartItems.Add(cartItem);
//       }
//       else
//       {
//         // If the item does exist in the cart,                  
//         // then add one to the quantity.                 
//         cartItem.Quantity++;
//       }
//       dbContext.SaveChanges();
//     }

//     public void Dispose()
//     {
//       if (dbContext != null)
//       {
//         dbContext.Dispose();
//         dbContext = null;
//       }
//     }

//     public string GetCartId()
//     {
//       if (HttpContext.Session[CartSessionKey] == null)
//       {
//         if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
//         {
//           HttpContext.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
//         }
//         else
//         {
//           // Generate a new random GUID using System.Guid class.     
//           Guid tempCartId = Guid.NewGuid();
//           HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
//         }
//       }
//       return HttpContext.Current.Session[CartSessionKey].ToString();
//     }

//     public List<CartItem> GetCartItems()
//     {
//       ShoppingCartId = GetCartId();

//       return dbContext.ShoppingCartItems.Where(
//           c => c.CartId == ShoppingCartId).ToList();
//     }
//   }
// }