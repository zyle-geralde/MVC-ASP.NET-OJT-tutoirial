using Microsoft.AspNetCore.Mvc;
using WebApplicationSession5.Models;

namespace WebApplicationSession5.Controllers
{
    public class ProductController : Controller
    {
        public static List<ProductModel> list = new();
        public IActionResult Index()
        {
            return View(list);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel product)
        {
            product.Id = Guid.NewGuid().ToString();

            if (product.Quantity < 0 || product.Price < 0)
            {
                ViewBag.ErrorMessage = "Quantity or Price should not be less than zero";
                return View();
            }

            list.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            ProductModel product = list.Where(product => product.Id == id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ProductModel product = list.Where(product => product.Id == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel product)
        {

            ProductModel find_product = list.Where(product_holder => product_holder.Id == product.Id).FirstOrDefault();

            if (product.Quantity < 0 || product.Price < 0)
            {
                ViewBag.ErrorMessage = "Quantity or Price should not be less than zero";
                return View();
            }

            find_product.Name = product.Name;
            find_product.Description = product.Description;
            find_product.Price = product.Price;
            find_product.Quantity = product.Quantity;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            ProductModel product = list.Where(product => product.Id == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(ProductModel product)
        {
            ProductModel find_product = list.Where(product_holder => product_holder.Id == product.Id).FirstOrDefault();
            if (find_product != null)
            {
                list.Remove(find_product);
            }

            return RedirectToAction("Index");
        }
    }
}
