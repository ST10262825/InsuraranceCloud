
using KCrafts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KCrafts.Controllers
{
    public class HomeController : Controller
    {

        private readonly KcraftContext _context;

        public HomeController(KcraftContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            // Retrieve products from the database
            var products = _context.Products.ToList();

            // Pass the list of products to the view
            ViewBag.Products = products;

            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Transaction()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult MyWork()
        {
            // Retrieve products from the database
            var products = _context.Products.ToList();

            // Pass the list of products to the view

            ViewBag.Products = products;

            return View();
        }
        public IActionResult ThankYou()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
