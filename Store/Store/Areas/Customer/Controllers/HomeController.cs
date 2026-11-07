using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Views;
using System.Diagnostics;

namespace Store.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index( FilterVM filter)
        { 
           var Products = _context.Products.AsQueryable();
            Products = Products.Include(p => p.Category);
            if (filter.ProductName is not null)
            {
                Products = Products.Where(p => p.Name.Contains(filter.ProductName ));
                ViewBag.ProductName = filter.ProductName;
            }
            if (filter.MinPrice >0)
            {
                Products = Products.Where(p =>( p.Price *p.Discount/100) >= filter.MinPrice);
                ViewBag.MinPrice = filter.MinPrice;
            }
            if (filter.MaxPrice > 0)
            {
                Products = Products.Where(p => (p.Price * p.Discount / 100) <= filter.MinPrice);
                ViewBag.MaxPrice = filter.MaxPrice;
            }
            if (filter.CategoryId > 0)
            {
                Products = Products.Where(p => p.CategoryId  ==filter.CategoryId);
                ViewBag.CategoryId = filter.CategoryId;
            }
            if (filter.BrandId > 0)
            {
                Products = Products.Where(p => p.BrandId == filter.BrandId);
                ViewBag.BrandId = filter.BrandId;
            }
            if(filter.IsHot)

                Products = Products.Where(p => p.Discount >50);


            var Categories = _context.Categories.ToList();
            var Brands = _context.Brands.ToList();
            ViewBag.Categories = Categories;
            ViewBag.Brands = Brands;

            Products=Products.Skip((filter.Page - 1) * 6).Take(6);
            return View(Products.ToList());

           
        }
       
        public IActionResult ProductDetails( int id)
        {
            var Product = _context.Products.Where(p => p.Id == id);

            if(Product is null) return NotFound();


            return View( Product);
        }
        public IActionResult Privacy()
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
