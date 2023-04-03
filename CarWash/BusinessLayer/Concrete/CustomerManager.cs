using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : IGenericService<Customer>
    {
        readonly ICustomerDal customerRepository;
        readonly Model model;
        readonly CarWashesDbContext context;
        public CustomerManager()
        {
            this.customerRepository = new CustomerRepository();
            this.model = new Model();
            this.context = new CarWashesDbContext();

        }
        public Model DeleteBL(int id) //buraya gelinecek
        {

            if (customerRepository.Delete(id))
            {
                model.StatuMessage = "Silme İşlemi gerçekleştirilmiştir.";
                model.Status = HttpStatusCode.OK;
                return model;
            }
            return model;
        }
        public Model GetAllListBL()
        {
            if (customerRepository.GetList() == null)
            {
                model.StatuMessage = "Listeleme işlemi başarısız";
                model.Status = HttpStatusCode.NotFound;
                return model;
            }
            model.models = customerRepository.GetList();
            model.Status = HttpStatusCode.OK;
            return model;

        }
        public Model InsertBL(Customer p)
        {
            //veritabanından Customer listesini çek
            var customers = context.Customers.ToList();
            //veritabanınadan çalışan listesini çek
            var employees = context.Employees.ToList();
            //girilen tckn yi incele hata varsa hata mesajı dön
            if (p.TCIdentifier.Length == 0 || p.TCIdentifier.Length > 11 & p.TCIdentifier.Length < 11)
            {
                model.StatuMessage = "TCKN doğru giriniz";
                model.Status = HttpStatusCode.BadRequest;
                return model;
            }
            //listedeki tüm elemanları dön
            foreach (var customer in customers)
            {
                //eğer tckn'ye göre listede bir veri varsa yeni kayı oluşturma var olan modeli bas
                if (customer.TCIdentifier == p.TCIdentifier)
                {
                    model.models = p;
                    model.Status = HttpStatusCode.OK;
                    //modeli basmadan önce varolan müşterinin abonelik durumunu incele sonra modeli ekrana bas 
                    if (p.Subscriber == true)
                    {
                        return model;
                    }
                    return model;
                }
            }
            //Müşteri kayıtında ilk olarak girilen isim ve soyisim kontrolleri yapılacak 
            if ((p.CustomerName == "" || p.CustomerName.Length < 2 || p.CustomerName.Length > 25) && p.CustomerLastName.Length > 25 || p.CustomerLastName.Length < 2)
            {
                model.StatuMessage = "Müşteri Ad ve Soyad hatalı";
                model.Status = HttpStatusCode.BadRequest;
                return model;
            }
            //yukarıda çektiğin çalışan tablosunu kontrol et gelen istekte ki çalışan id ile 
            //uyuşmazlık varsa hata mesajı dön
            foreach (var employee in employees)
            {
                if (employee.EmployeeId == p.EmployeeId)
                {
                    model.models = p;
                }
            }
            //İsim ve soyisim den sonra abone olup olmama durumu sogulanacak
            if (p.Subscriber == true)
            {
                if (customerRepository.Insert(p))
                {
                    model.models = p;
                    model.Status = HttpStatusCode.OK;
                    return model;
                }
            }
            if (customerRepository.Insert(p))
            {
                model.models = p;
                model.Status = HttpStatusCode.OK;
            }
            return model;
        }
        public Model UpdateBL(Customer p)
        {
            //Güncellecek olan veriyi id ye göre çek 
            var value = context.Customers.FirstOrDefault(c => c.CustomerId == p.CustomerId);
            //TCKN güncellenemez.
            if (value.TCIdentifier != p.TCIdentifier)
            {
                model.StatuMessage = "TCKN değiştirlemez";
                model.Status = HttpStatusCode.NotFound;
                return model;
            }
            //ad-soyad değişikliğinde belirlenen şartlar dışına çıkarsa blok içerisinde ki model mesajını dön    
            if ((value.CustomerName == "" || value.CustomerName.Length < 3 || value.CustomerName.Length > 25))
            {
                model.StatuMessage = "Güncelleme gerçekleşmedi..";
                model.Status = HttpStatusCode.BadRequest;
                return model;
            }
            if (value.CustomerLastName.Length > 25)
            {
                model.StatuMessage = "Güncelleme gerçekleşmedi..";
                model.Status = HttpStatusCode.BadRequest;
                return model;
            }
            //Abone olmak isteyen müşteri.
            if (value.Subscriber == false && p.Subscriber == true)
            {
                model.models = p;
            }
            //Abonelikten çıkmak isteyen müşteri
            else if (value.Subscriber == true && p.Subscriber == false)
            {
                model.models = p;
            }
            //Yukarıda ki filtreleden geçen müşterini güncelleme işlemini tamamlayacak olan adım 
            if (customerRepository.Update(p))
            {
                model.models = p;
                model.Status = HttpStatusCode.OK;
            }
            return model;
        }
    }
}



