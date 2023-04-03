using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public int RecipeDiscountId { get; set; }
        public int CustomerId { get; set; }
        public string RecipeName { get; set; }
        public int  RecipePrice { get; set; }
        public ICollection<Customer>? Customers { get; set; }

        public ICollection<RecipeDiscount>? RecipeDiscounts { get; set; }


    }
}
