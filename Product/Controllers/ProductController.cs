using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Products = Product.Models.MyProduct;

namespace Product.Controllers
{
    public class ProductController : Controller
    {
        // Static list of products for demonstration purposes
        private static List<Products> _products = new List<Products>
        {
            new Products { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 1200, ImageUrl = "https://th.bing.com/th/id/OIP.jRqNLekZ-LDtGZ1sFnK9RgAAAA?rs=1&pid=ImgDetMain" },
            new Products { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 800, ImageUrl = "https://th.bing.com/th/id/OIP.JnxK244va8dmrjAE7bqGHAHaJ4?w=147&h=196&c=7&r=0&o=5&dpr=1.3&pid=1.7" },
            new Products { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 200, ImageUrl = "https://th.bing.com/th/id/OIP.JjcpExhYJsBDWPMpPKD_LAHaJB?w=151&h=184&c=7&r=0&o=5&dpr=1.3&pid=1.7" }
        };

        // GET: /Product/Index
        public IActionResult Index()
        {
            return View(_products);
        }

        // GET: /Product/AddProduct/{id}
        public IActionResult AddProduct(int id)
        {
            // Retrieve the product based on the passed id
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: /Product/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(); // This returns the Add.cshtml view with an empty form.
        }

        // POST: /Product/Add
        [HttpPost]
        public IActionResult Add(Products newProduct)
        {
            if (ModelState.IsValid)
            {
                // Assign a new Id (for demo purposes, use max id + 1)
                newProduct.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(newProduct);
                // Redirect to the Index action to see the updated list.
                return RedirectToAction("Index");
            }

            // If there are validation errors, redisplay the form.
            return View(newProduct);
        }
    }
}
