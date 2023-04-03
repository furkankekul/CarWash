using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        IGenericService<Recipe> recipeManager;
        

        public RecipeController()
        {
            this.recipeManager = new RecipeManager();
        }


        [HttpPost]
        public IActionResult RecipeAdd(Recipe r)
        {
            Model model = new Model();
            model = recipeManager.InsertBL(r);
            return StatusCode((int)model.Status, model.models ?? model.StatuMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult RecipeDelete(int id)
        {
            Model model = new Model();
            model = recipeManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpGet]
        public IActionResult RecipeGetList()
        {
            recipeManager.GetAllListBL();
            return Ok();
        }
        [HttpPut]
        public IActionResult RecipeUpdate(Recipe r)
        {
            Model model = new Model();
            model = recipeManager.UpdateBL(r);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }


        [HttpPost("AllRecipeAdd")]
        public IActionResult AllRecipeAdd([FromBody] List<Recipe> recipes)
        {
            foreach (var item in recipes)
            {
                recipeManager.InsertBL(item);
            }
            return Ok();
        }











    }
}
