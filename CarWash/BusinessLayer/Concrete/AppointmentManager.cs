using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppointmentManager : IGenericService<Appointment>
    {
        readonly IAppointmentDal appointmentRepository;
        readonly Model model;
        readonly CarWashesDbContext context;

        public AppointmentManager()
        {
            this.appointmentRepository = new AppointmentRepository();
            this.context = new CarWashesDbContext();
            this.model = new Model();
        }
        public Model DeleteBL(int id)
        {
            if (appointmentRepository.Delete(id))
            {
                model.StatuMessage = "Randevu Silindi";
                model.Status = System.Net.HttpStatusCode.OK;
                return model;
            }
            model.StatuMessage = "Randevu silme işleminde bir hata meydana geldi.";
            model.Status = System.Net.HttpStatusCode.NotFound;
            return model;

        }  //Randevu silme işlemin de fiyat olarak ceza uygulaanacak buraya gelinecek 
        public Model GetAllListBL()
        {
            if (appointmentRepository.GetList == null)
            {
                model.StatuMessage = "Randevu Listesi Null Olamaz.!";
                model.Status = System.Net.HttpStatusCode.NotFound;
                return model;
            }
            else
            {
                model.models = appointmentRepository.GetList;
                model.Status = System.Net.HttpStatusCode.OK;
            }
            return model;
        }
        public Model InsertBL(Appointment p)
        {
            //p değerini id'sine göre  veritabanından çekecek sorguyu yaz
            var employee1 = context.Employees.Find(p.EmployeeId);
            //Veritabanından işçi tablosunu çekecek metot sorguyu yaz
            var employees = context.Employees.ToList();
            //veritabanından randevu tablosunu çekecek metot sorguyu yaz
            var appointments = context.Appointments.ToList();
            //Dışarıdan gelen id değerine göre işçi tablosundaki işçileri taramak için foreach yaz 
            foreach (var employee in employees)
            {
                //eğer gelen işçi null'sa hata dönder
                if (employee1 == null)
                {
                    model.StatuMessage = "Çalışan id boş geçilemez ";
                    model.Status = System.Net.HttpStatusCode.BadRequest;
                    return model;
                }
                //null değilse dışarıdan gelen id tablodaki id değerine eşitse bu blok'a
                else if (employee1.EmployeeId == employee.EmployeeId)
                {
                    //Dışarıdan gelen Randevu değerine göre randevu tablosundaki randevuları tara 
                    foreach (var appointment in appointments)
                    {
                        //eğer dışardan gelen randevu başlangıç ve bitiş tablodaki başlangıç ve bitiş tarihe eşitse bu blok'a gir
                        if (appointment.AppointmentEntryTime == p.AppointmentEntryTime && appointment.AppointmentEndTime == p.AppointmentEndTime)
                        {
                            //Yukarıdaki zaman aralığında dışarıdan gelen çalışan id değeri ile tablodan gelen çalışan id birbirine eşitse
                            //bu bloğa gir ve model olarak haata dönder 
                            if (employee1.EmployeeId == appointment.EmployeeId)
                            {
                                model.StatuMessage = "Seçilen zaman aralığındaki randevu doludur.";
                                model.Status = System.Net.HttpStatusCode.NotFound;
                                return model;

                            }
                            else if (appointmentRepository.Insert(p))
                            {
                                model.models = p;
                                model.Status = System.Net.HttpStatusCode.OK;
                                return model;
                            }
                        }
                    }
                    if (appointmentRepository.Insert(p))
                    {
                        model.models = p;
                        model.Status = System.Net.HttpStatusCode.OK;
                        return model;
                    }
                }
            }
            return model;
        }
        public Model UpdateBL(Appointment p)
        {
            //Güncellenecek olan randevuyu veritabanından randevuid' ye göre çek
            //postman da güncellenecek olan id yi verdiğin zaman güncellenecek alanları da orda ver 
            var appointment1 = context.Appointments.Find(p.AppointmentId);
            //veritabanından randevu listesini çek ve güncellenecek olan randevu da işçi veya randevu zaman
            //arlığın da çakışan var mı kontroolerini yap. 
            var appointments = context.Appointments.ToList();
            //veritabanından çektiğin randevu listesini dön
            foreach (var appointment in appointments)
            {
                //güncellenecek olan randevu da zaman aralığın da çakışan var mı varsa blok içerisine gir 
                if (appointment.AppointmentEntryTime == appointment1.AppointmentEntryTime && appointment.AppointmentEndTime == appointment1.AppointmentEndTime)
                {

                    //Çakışan zaman aralığın da güncellenecek olan çalışanın zaten randevusu varsa model olarak hata dön
                    if (appointment.EmployeeId == appointment1.EmployeeId)
                    {
                        model.StatuMessage = "Seçilen işçinin zaman aralığında randevusu var lütfen başka bir randevu seçin";
                        model.Status = System.Net.HttpStatusCode.BadRequest;
                        return model;
                    }
                    else if (appointmentRepository.Update(p))
                    {
                        model.models = p;
                        model.Status = System.Net.HttpStatusCode.OK;
                        return model;
                    }
                }
                //randevu zaman aralığın da çakışan yoksa o aralıkta  işçinin randevusu var mı 
                //kontrol et.
                else if (appointment.EmployeeId == appointment1.EmployeeId)
                {
                    model.StatuMessage = "Seçilen randevu saatinde seçtiğin işçinin randevusu var";
                    model.Status = System.Net.HttpStatusCode.BadRequest;
                    return model;
                }
                //eğer saatte ve çalışan da sıkıntı yoksa randevuyu güncelle
                if (appointmentRepository.Update(p))
                {
                    model.models = p;
                    model.Status = System.Net.HttpStatusCode.OK;
                    return model;
                }
            }
            return model;
        }

    }
}
