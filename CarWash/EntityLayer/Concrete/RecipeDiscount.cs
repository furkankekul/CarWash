using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RecipeDiscount
    {
        [Key]
        public int RecipeDiscountId { get; set; }
        public double  Discount { get; set; }
        public ICollection<Recipe>? Recipes { get; set; }


    }
}
