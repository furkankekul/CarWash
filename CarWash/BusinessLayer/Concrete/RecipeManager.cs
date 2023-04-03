using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RecipeManager : IGenericService<Recipe>
    {
        readonly IRecipeDal recipeRepository;
        readonly Model model;
        readonly CarWashesDbContext context;

        public RecipeManager()
        {
            this.recipeRepository = new RecipeRepository();
            this.model = new Model();
            this.context = new CarWashesDbContext();
        }
        
        public Model DeleteBL(int id)
        {
            if (recipeRepository.Delete(id))
            {
                model.Status = System.Net.HttpStatusCode.OK;
                model.StatuMessage = "Tarife Silme İşlemi başarılı bir şekilde gerçekleşmiştir";
                return model;
            }
            model.StatuMessage = "Tarife silme işlemi başarısız.";
            model.Status = System.Net.HttpStatusCode.NotFound;
            return model;

          ;
        }
        public Model GetAllListBL()
        {
            if (recipeRepository.GetList==null)
            {
                model.StatuMessage = "Liste boş dönemez";
                model.Status = System.Net.HttpStatusCode.BadRequest;
            }
            return model;

        }
        public Model InsertBL(Recipe p)
        {
            //veritabanın da varolan tarife yeniden eklenemez.
            var recipes = context.Recipes.ToList();
            foreach (var recipe in recipes)
            {
                if (recipe.RecipeName == p.RecipeName)
                {
                    model.StatuMessage = "Bu tarife zaten var.";
                    model.Status = System.Net.HttpStatusCode.NotFound;
                    return model;
                }
            }
            if (p.RecipePrice < 0)
            {
                model.StatuMessage = "Tarife fiyatı 0'dan Küçük olamaz";
                model.Status = System.Net.HttpStatusCode.NotFound;
                return model;
            }
            else if (p.RecipeName.Length < 2 || p.RecipeName.Length > 50)
            {
                model.StatuMessage = "Tarife ismini belirlenen uzunlukta girin (2-50)";
                model.Status = System.Net.HttpStatusCode.BadRequest;
                return model;
            }
            if (recipeRepository.Insert(p))
            {
                model.models = p;
                model.Status = System.Net.HttpStatusCode.OK;
            }

            return model;
        }
        public Model UpdateBL(Recipe p)
        {
            if (p.RecipePrice < 0)
            {
                model.StatuMessage = "Tarife fiyatı 0'dan Küçük olamaz";
                model.Status = System.Net.HttpStatusCode.NotFound;
                return model;
            }
            else if (p.RecipeName.Length < 2 || p.RecipeName.Length > 50)
            {
                model.StatuMessage = "Tarife ismini belirlenen uzunlukta girin";
                model.Status = System.Net.HttpStatusCode.BadRequest;
                return model;
            }
            if (recipeRepository.Update(p))
            {
                model.models = p;
                model.Status = System.Net.HttpStatusCode.OK;
            }
            return model;
        }



    }
}
