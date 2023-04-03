using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        bool Insert(T p);
        bool Delete(int id);
        bool Update(T p);
        List<T> GetList();

    }
}
