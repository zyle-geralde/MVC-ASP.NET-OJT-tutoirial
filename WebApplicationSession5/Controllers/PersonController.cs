using Microsoft.AspNetCore.Mvc;
using WebApplicationSession5.Models;

namespace WebApplicationSession5.Controllers
{
    public class PersonController : Controller
    {
        public static List<PersonModel> list  = new();
        //action method for get
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
        public IActionResult Create(PersonModel person)
        {
            person.Id = Guid.NewGuid().ToString();
            int personObjectAge = int.Parse(person.Age+"");

            if (personObjectAge < 0)
            {
                //For passing errors to front end
                ViewBag.ErrorMessage = "Age should not be zero";
                return View();
            }



            list.Add(person);
            return RedirectToAction("Index"); //redirection to same controller but diffent action method
        }

        //Passing id to route - in view enable something their
        public IActionResult Details(string id)
        {
            PersonModel person = list.Where(person => person.Id == id).FirstOrDefault();
            return View(person);
        }
    }
}
