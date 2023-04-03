using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using System.Security.Cryptography.Xml;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        readonly IGenericService<Appointment> appointmentManager;
        public AppointmentController()
        {
            this.appointmentManager = new AppointmentManager();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Model model = new Model();
            model = appointmentManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpGet("{AppointmentList}")]
        public IActionResult GetAppointmentList()
        {
            var value = appointmentManager.GetAllListBL();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody] Appointment appointment)

        {
            Model model = new Model();
            model = appointmentManager.InsertBL(appointment);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpPut]
        public IActionResult UpdateAppointment(Appointment appointment)
        {
            Model model = new Model();
            model = appointmentManager.UpdateBL(appointment);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpPost("AllAppointmentAdd")]
        public IActionResult AllAppointmentAdd([FromBody] List<Appointment> appointments)
        {
            Model model = new Model();
            foreach (var appointment in appointments)
            {
                appointmentManager.InsertBL(appointment);
            }
            return Ok();
        }

        [HttpGet("UpdateAppointmentStatus")]
        public IActionResult GetAppointmnent([FromQuery]int id)
        {
            Model model = new Model();
            CarWashesDbContext context = new CarWashesDbContext();
            var value = context.Appointments.Find(id);
            if (value==null)
            {
                model.StatuMessage = "Randevu bulunamadı";
                model.Status = System.Net.HttpStatusCode.NotFound;
                return StatusCode((int)model.Status,model.StatuMessage ?? model.models);
            }
            else if (value.AppointmentStatus == false)
            {
                value.AppointmentStatus = true;
                model = appointmentManager.UpdateBL(value);
                model.Status = System.Net.HttpStatusCode.OK;
                return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
            }
            model.Status = System.Net.HttpStatusCode.NotFound;
            model.StatuMessage = "İşlem başarısız.";
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);

            //bu id ye sahip bir randevuyu çek
            //status true çek
            //update'e gönder
            //return ok 
        }



    }
}
