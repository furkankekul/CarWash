using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]  
        public bool AppointmentStatus { get; set; }
        public DateTime AppointmentEntryTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public Customer? Customer { get; set; }   
        public Employee? Employee { get; set; }


    }
}
