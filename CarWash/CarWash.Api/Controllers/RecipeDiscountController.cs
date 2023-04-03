using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeDiscountController : Controller
    {
        IGenericService<RecipeDiscount> recipeDiscountManager;
       

        public RecipeDiscountController()
        {
            this.recipeDiscountManager = new RecipeDiscountManager();
        }

        [HttpPost]
        public IActionResult AddRecipeDiscount(RecipeDiscount r)
        {
            Model model = new Model();
            model = recipeDiscountManager.InsertBL(r);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);

        }

        [HttpDelete]
        public IActionResult DeleteRecipeDiscount(int id)
        {
            Model model = new Model();
            model = recipeDiscountManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpGet]
        public IActionResult GetRecipeDiscount()
        {
            var value = recipeDiscountManager.GetAllListBL();
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateRecipeDiscount(RecipeDiscount r)
        {
            Model model = new Model();
            model = recipeDiscountManager.UpdateBL(r);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

    }
}
