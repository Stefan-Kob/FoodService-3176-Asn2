using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : Controller
    {

        // DTO to used by this controller
        public sealed record Food(int Id, string Name, string Description, int Calories);

        // List of foods pre seeded
        private static readonly List<Food> _foods = new()
        {
            new Food(1, "Applesauce", "mhmhmhm saucy sauce", 135),
            new Food(2, "Polish Sausage", "Best found at central fresh meat market", 199),
            new Food(3, "Roasted almonds", "People eat these?", 40)
        };

        // GET: /api/food
        [HttpGet]
        public ActionResult<List<Food>> GetAll()
        {
            return Ok(_foods);
        }

        // GET: /api/food/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Food> GetById(int id)
        {
            var item = _foods.Find(f => f.Id == id);
            if (item is null)
            {
                return NotFound(new { Message = $"Food with id '{id}' not found" });
            }

            return Ok(item);
        }
    }
}
