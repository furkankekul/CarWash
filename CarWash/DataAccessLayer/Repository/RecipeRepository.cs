using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class RecipeRepository : IGenericDal<Recipe>, IRecipeDal
    {
        CarWashesDbContext context = new CarWashesDbContext();
        public bool Delete(int id)
        {
            var value = context.Recipes.Find(id);
            context.Recipes.Remove(value);
            return context.SaveChanges() > 0 ? true : false;
        }

        public List<Recipe> GetList()
        {
            return context.Recipes.ToList();
        }

        public bool Insert(Recipe recipe)
        {
            context.Recipes.Add(recipe);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Recipe recipe)
        {
            context.Recipes.Update(recipe);
            return  context.SaveChanges() > 0 ? true : false;
        }
    }
}



