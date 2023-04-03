using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CustomerRepository : IGenericDal<Customer>, ICustomerDal
    {
        CarWashesDbContext context = new CarWashesDbContext();
        public bool Delete(int id)
        {
            var value = context.Customers.Find(id);
            context.Customers.Remove(value);
            return context.SaveChanges() > 0 ? true : false;
        }

        public List<Customer> GetList()
        {
            return context.Customers.ToList();
        }

        public bool Insert(Customer customer)
        {
            context.Customers.Add(customer);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Customer customer)
        {
            context.Customers.Update(customer);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}

#region Repository sınıfı hakkında bilgi
//Reposiory sınıfında böyle repoları da oluşturuabilirsin
//repositry sınıfına bir tane GenericRepository<> sınıfı olulturup IGenericDal<> 'dan miras almasını sağlayıp
//IGenericDal'dan implement olan metotları burada doldurabilirsin.
//Daha sınra DataAccessLayer Katmanında EntityFrameworkCore dosyası oluşturup içerisine geriye kalan tüm entitylerin
//repositorylerini oluşturup Repository dosyasında ki GenericRepository<> sınıfından miras almasını sağlayabilirisn
//Bu da başka bir yöntemdir.
#endregion
