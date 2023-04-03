using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IGenericService<Employee>
    {
        readonly IEmployeeDal employeeRepository;
        readonly Model model;
        readonly CarWashesDbContext context;
        public EmployeeManager()
        {
            this.employeeRepository = new EmployeeRepository();
            this.model = new Model();
            this.context = new CarWashesDbContext();
        }

        public Model DeleteBL(int id)
        {
            if (employeeRepository.Delete(id))
            {
                model.StatuMessage = "Silme İşlemi gerçekleştirilmiştir.";
                model.Status = HttpStatusCode.OK;
                return model;
            }
            model.StatuMessage = "Silme işlemi gerçekleşmemiştir.";
            model.Status = HttpStatusCode.NotFound;
            return model;
        }

        public Model GetAllListBL()
        {
            if (employeeRepository.GetList == null)
            {
                model.StatuMessage = "Liste boş dönemez.";
                model.Status = HttpStatusCode.NotFound;
            }
            return model;
        }

        public Model InsertBL(Employee p)
        {
            //varolan işçi eklenemez
            var employee = context.Employees.ToList();





            if ((p.EmployeeName == "" || p.EmployeeName.Length < 3 || p.EmployeeName.Length > 25) && (p.EmployeeLastName.Length > 25 || p.EmployeeLastName.Length < 2))
            {
                model.StatuMessage = "İşçi ad-soyad hatalı girdiniz Lütfen belirtilen uzunlukta işlem yapınız(5-25)";
                model.Status = HttpStatusCode.BadRequest;
                return model;
            }
            if (employeeRepository.Insert(p))
            {
                model.models = p;
                model.Status = HttpStatusCode.OK;
            }
            return model;
        }

        public Model UpdateBL(Employee p)
        {
            if ((p.EmployeeName == "" || p.EmployeeName.Length < 3 || p.EmployeeName.Length > 25))
            {
                model.StatuMessage = "Güncelleme gerçekleşmedi..";
                model.Status = HttpStatusCode.BadRequest;
                return model;
            }
            if (p.EmployeeLastName.Length > 25)
            {
                model.StatuMessage = "Güncelleme gerçekleşmedi..";
                model.Status = HttpStatusCode.BadRequest;
                return model;
            }
            if (employeeRepository.Update(p))
            {
                model.models = p;
                model.Status = HttpStatusCode.OK;
            }
            return model;
        }



    }
}
