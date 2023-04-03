using EntityLayer.Concrete;

namespace CarWash.Api.Controllers
{
    public class ModelController
    {
        public int? AppointmentId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? AppointmentEntryTime { get; set; }
        public DateTime? AppointmentEndTime { get; set; }

        public int? RecipeId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerLastName { get; set; }
        public bool? Subscriber { get; set; }

        public string? EmployeeName { get; set; }
        public string? EmployeeLastName { get; set; }

        
        public int? RecipeDiscountId { get; set; }
        public string? RecipeName { get; set; }
        public int? RecipePrice { get; set; }
        public double? Discount { get; set; }


    }
}
