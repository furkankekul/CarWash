using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class 
    {
        public Model InsertBL(T p);
        public Model DeleteBL(int id);
        public Model UpdateBL(T p);
        public Model GetAllListBL();
       
    }
    
    
}
