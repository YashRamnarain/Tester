using _21914397_Ramnarain_Yasvhir_Assignment_1.Models;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;

namespace _21914397_Ramnarain_Yasvhir_Assignment_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static MealPlan selectedMealPlan;

        private static readonly List<MealPlan> mealPlans = new List<MealPlan>
        {
                new MealPlan { Id = 1, Food = "Deluxe Hamburger", Image = "https://jahzkitchen.com/wp-content/uploads/2021/01/Double-JAH-Deluxe-Burger.jpg", Drink = "Soft Drink", Price = 70 },
                new MealPlan { Id = 2, Food = "Russian in a roll", Image = "https://img.postershop.me/6563/Products/2048857_1620040069.8094_original.jpeg", Drink = "Soft Drink", Price = 50 },
                new MealPlan { Id = 3, Food = "Vegetarian Breyani", Image="https://www.yummytummyaarthi.com/wp-content/uploads/2014/08/1-47.jpg", Drink = "Soft Drink", Price = 100 }
        };
            

        public IActionResult Index()
        {            
            return View(mealPlans);
        }

        [HttpPost]
        public IActionResult SelectMealPlan(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Please select a meal plan.";
                return RedirectToAction(nameof(Index));
            }

            if (selectedMealPlan != null)
            {
                TempData["ErrorMessage"] = "You have already selected a meal plan.";
                return RedirectToAction(nameof(Index));
            }

            selectedMealPlan = mealPlans.FirstOrDefault(MealPlan => MealPlan.Id == id);           
            return RedirectToAction(nameof(Confirmation));
        }

        public IActionResult ResetPlan()
        {         
            selectedMealPlan = null;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Confirmation()
        {
            if (selectedMealPlan == null)
            {
                TempData["ErrorMessage"] = "Please select a meal plan.";
                return RedirectToAction(nameof(Index));
            }

            return View(selectedMealPlan);
        }
    }
}