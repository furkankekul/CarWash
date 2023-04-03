using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer   
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(11)]
        public string TCIdentifier { get; set; }
        public int EmployeeId { get; set; }
        public int RecipeId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public bool Subscriber { get; set; }
        public Appointment? Appointment { get; set; }
        public Employee? Employee { get; set; }
        public Recipe? Recipe { get; set; }

       
    }
}
