using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class AppointmentRepository : IGenericDal<Appointment>, IAppointmentDal
    {
        CarWashesDbContext context = new CarWashesDbContext();
        public bool Delete(int id)
        {
            var value = context.Appointments.Find(id);
            context.Appointments.Remove(value);
            return context.SaveChanges() > 0 ? true : false;
        }

        public List<Appointment> GetList()
        {
            return context.Appointments.ToList();
        }

        public bool Insert(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Appointment appointment)
        {
            context.Appointments.Update(appointment);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
