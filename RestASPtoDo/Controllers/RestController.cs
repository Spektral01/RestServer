using Microsoft.AspNetCore.Mvc;
using RestASPtoDo.Models;
using System.Data.SqlTypes;

namespace RestASPtoDo.Controllers
{
    public class RestController
    {
        /*[ApiController]
        [Route("[controller]")]*/
        /* public class UserController : ControllerBase
         {
             private static readonly string[] names = new[] { "A", "B", "C" };
             private int idCounter = 0;
             [HttpPost] //Create
             public User Post([FromBody] User item)
             {
                 item.Id = idCounter++;
                 return item;
             }
             [HttpGet] //Read
             public User[] Get()
             {
                 var r = new Random();
                 return Enumerable.Range(1, 3).Select(i => new User
                 {
                     Id = i,
                     Name = names[r.Next(names.Length)],
                     Age = r.Next(20, 50) + i
                 }).ToArray();
             }

             [HttpGet] //Read
             public User Get(int id)
             {
                 var r = new Random();
                 return new User
                 {
                     Id = id,
                     Name = names[r.Next(names.Length)],
                     Age = r.Next(20, 50)
                 };
             }
             [HttpPut("{id")] //Update
             public User Put(int id, [FromBody] User item)
             {
                 item.Id = id;
                 return item;
             }
             [HttpDelete("{id}")]
             public User Delete(int id)
             {
                 var r = new Random();
                 return new User
                 {
                     Id = id,
                     Name = names[r.Next(names.Length)],
                     Age = (r.Next(20, 50))
                 };
             }
         }*/
        public class User
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public int Age { get; set; }
        }
        public class UserController : ControllerBase
        {
            [HttpGet, Route("Ping")]
            public List<User> Ping()
            {
                User Nat = new User();
                Nat.Name = "Nataly";
                Nat.Id = 1;
                Nat.Age = 21;

                User Gre = new User();
                Gre.Name = "Gregory";
                Gre.Id = 2;
                Gre.Age = 20;

                List<User> list = new List<User>();
                list.Add(Nat);
                list.Add(Gre);

                return list;

            }
        }

        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            Product[] products = new Product[]
            {
            new Product
            {
                Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1
            },
            new Product
            {
                Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M
            },
            new Product
            {
                Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M
            }
            };

            [HttpGet]
            public IEnumerable<Product> GetAllProducts()
            {
                return products;
            }

            [HttpGet("{id}")]
            public ActionResult<Product> GetProduct(int id)
            {
                var product = products.FirstOrDefault((p) => p.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                return product;
            }
        }
    }
}

