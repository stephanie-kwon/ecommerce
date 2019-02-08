using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
using Stripe;
using System.Text.RegularExpressions;


namespace Ecommerce.Controllers
{
    public class HomeController : Controller 
    {
        private YourContext dbContext;
        public HomeController(YourContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        [Route("/charge")]
        public IActionResult Charge(string stripeEmail, string stripeToken, int amount)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions {
                Amount = (amount * 100),
                Description = "sample charge",
                Currency = "usd",
                CustomerId = customer.Id
            });
            
            return View();
        }


        [HttpGet]
        [Route("/login")]
        public ViewResult logreg(){
            
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult register(User user)
        {
            System.Console.WriteLine("*********************");
            System.Console.WriteLine("am  i in register?!?");
            if(ModelState.IsValid)

            {    
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                ModelState.AddModelError("Email", "Email already in use.");
                return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);


                User newUser = new User
                {
                    Email = user.Email,
                    Password = user.Password
                };

                dbContext.Add(newUser);
                dbContext.SaveChanges();


                HttpContext.Session.SetInt32("id", newUser.userId);
                HttpContext.Session.SetString("Email", newUser.Email);
                int? id_registered = HttpContext.Session.GetInt32("id");
                return RedirectToAction("index");

            } else {
                System.Console.WriteLine("failed");
                return View("LogReg");
            }
        }

        
        [HttpPost]
        [Route("/Log")]
        public IActionResult Log (string login_Email, string login_Password)
        {
            LoginUser bob = new LoginUser
            {
                login_Email = login_Email,
                login_Password = login_Password
            };
            if(TryValidateModel(bob))
            {
                var userinDB = dbContext.Users.FirstOrDefault(u => u.Email == login_Email);
                
                if(userinDB == null)
                {
                    // ModelState.AddModelError("login_Email", "Invalid Email");
                    ViewBag.EmailError = "Invalid Email";
                    return View("LogReg");
                }

                var hasher = new PasswordHasher<User>();
                var result = hasher.VerifyHashedPassword(userinDB, userinDB.Password, login_Password);
                // if(userinDB.Password != login_Password)
                if(result == 0)
                {
                    System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$");
                    // ModelState.AddModelError("login_Password", "Invalid Email");
                    ViewBag.PasswordError = "Invalid Password";
                    return View("LogReg");
                }             

            HttpContext.Session.SetInt32("id", userinDB.userId);
            HttpContext.Session.SetString("Email", userinDB.Email);
            int? logged_in_id = HttpContext.Session.GetInt32("id");
         
            System.Console.WriteLine("!!!!!!!!!!!!!");
            System.Console.WriteLine("***************");
            System.Console.WriteLine("signing innn!!");
            return RedirectToAction("index");
        
            }
            else 
            {
                System.Console.WriteLine("not working?");
                ViewBag.EmailError = "Invalid input";
            
                return View("LogReg"); 
            }
            
        }
        
        
        [HttpGet]
        [Route("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            // System.Console.WriteLine("************");
            // System.Console.WriteLine("logging out!!");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/women-maintops")]
        public ViewResult Tops()
        {
            List<Item> allMainTops = dbContext.Items.ToList();
            return View(allMainTops);
        }
        [HttpGet]
        [Route("/tops-swim")]
        public ViewResult SwimTops() 
        {
            List<Item> allSwim = dbContext.Items.ToList();
            return View(allSwim);
        }
        [HttpGet]
        [Route("/women-tanks")]
        public ViewResult Tanks()
        {
            List<Item> womenTanks = dbContext.Items.ToList();
            return View(womenTanks);
        }

        [HttpGet]
        [Route("/women-dresses")]
        public ViewResult Dress()
        {
            List<Item> dresses = dbContext.Items.ToList();
            return View(dresses);
        }
        
        [HttpGet]
        [Route("/women-shortsleeves")]
        public ViewResult ShortSleeve()
        {
            List<Item> womenShortSleeves = dbContext.Items.ToList();
            return View(womenShortSleeves);
        }

        [HttpGet]
        [Route("/women-longsleeves")]
        public ViewResult LongSleeve()
        {
            List<Item> womenLongSleeves = dbContext.Items.ToList();
            return View(womenLongSleeves);
        }

        [HttpGet]
        [Route("/women-sweaters")]
        public ViewResult womenSweater()
        {
            List<Item> womenSweaters = dbContext.Items.ToList();
            return View(womenSweaters);
        }
        [HttpGet]
        [Route("/women-hoodies")]
        public ViewResult womenHoodies()
        {
            List<Item> womenHoodies = dbContext.Items.ToList();
            return View(womenHoodies); 
        }
        [HttpGet]
        [Route("/women-jackets")]
        public ViewResult womenJackets()
        {
            List<Item> womenJackets = dbContext.Items.ToList();
            return View(womenJackets);           
        }

        [HttpGet]
        [Route("/women-all")]
        public ViewResult womenAll()
        {
            List<Item> womenAll = dbContext.Items.OrderBy(a => Guid.NewGuid()).ToList();
            return View(womenAll);       
        }

        [HttpGet]
        [Route("/men")]
        public ViewResult men()
        {
            return View();
        }


        [HttpGet]
        [Route("/navbar")]
        public ViewResult navBar()
        {
            return View();
        }

        [HttpGet]
        [Route("/addProduct")]
        public ViewResult Form()
        {
            return View();
        }

        [HttpPost]
        [Route("/addProduct")]
        public IActionResult Create(Item p)
        {
            if(ModelState.IsValid)
            {    

                Item newProd = new Item
                {
                    itemName = p.itemName,
                    itemCategory = p.itemCategory,
                    itemDesc = p.itemDesc,
                    itemImage = p.itemImage,
                    itemPrice = p.itemPrice
                };

                dbContext.Add(newProd);
                dbContext.SaveChanges();
                return RedirectToAction("index");

            } else {
                System.Console.WriteLine("failed");
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                return View("form");
            }
        }

        [HttpGet]
        [Route("women/{itemId}")]
        public ViewResult specificProd(int itemId)
        {
            System.Console.WriteLine("!!!!!!!!!!!!");
            System.Console.WriteLine(" am i hitting this?");

            System.Console.WriteLine(itemId);

            Item oneItem = dbContext.Items.FirstOrDefault(x => x.itemId == itemId);        
            return View(oneItem);
        }
    

        [HttpGet]
        [Route("/Cart")]
        public ViewResult Cart()
        {
            return View();
        }

        // [HttpGet]
        // [Route("add/{itemId}")]
        // public IActionResult Add(int itemId)
        // {
        //     Bought newItem = new Bought
        //     {
        //         userId = (int)HttpContext.Session.GetInt32("id"),
        //         itemId = itemId
        //     };
        //     dbContext.Add(newItem);
        //     dbContext.SaveChanges();

        //     List<Item> allItems = dbContext.Items.Include(x => x.boughts).ThenInclude(a => a.users).ToList();
        //     return RedirectToAction("specificProd", allItems);
        // }
    }

}