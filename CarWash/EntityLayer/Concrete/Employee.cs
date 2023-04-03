using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }

        public ICollection<Customer>? Customers { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
