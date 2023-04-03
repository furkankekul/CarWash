using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RecipeDiscountManager : IGenericService<RecipeDiscount>
    {
        IRecipeDiscountDal recipeDiscountRepository;
        Model model = new Model();
        public RecipeDiscountManager()
        {
            this.recipeDiscountRepository = new RecipeDiscountRepository();
        }
        public Model DeleteBL(int id)
        {
           recipeDiscountRepository.Delete(id);
            return model;
        }

        public Model GetAllListBL()
        {
            if (recipeDiscountRepository.GetList==null)
            {
                model.StatuMessage = "Liste boş dönemez";
                model.Status = System.Net.HttpStatusCode.NotFound;
            }
            return model;
        }
       

        public Model InsertBL(RecipeDiscount p)
        {
            recipeDiscountRepository.Insert(p);
            return model;
        }

        public Model UpdateBL(RecipeDiscount p)
        {
            recipeDiscountRepository.Update(p);
            return model;
        }
    }
}
