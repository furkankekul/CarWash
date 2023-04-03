using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EmployeeRepository : IGenericDal<Employee>, IEmployeeDal
    {
        CarWashesDbContext context = new CarWashesDbContext();
        public bool Delete(int id)
        {
            var value = context.Employees.Find(id);
            context.Employees.Remove(value);
            return context.SaveChanges() > 0 ? true : false;
        }

        public List<Employee> GetList()
        {

            return context.Employees.ToList();
        }

        public bool Insert(Employee employee)
        {
            context.Employees.Add(employee);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Employee employee)
        {
            context.Employees.Update(employee);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
