using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        IGenericService<Customer> customerManager;
       

        public CustomerController()
        {
            this.customerManager = new CustomerManager();
        }

        [HttpDelete("{id}")]
        public IActionResult CustomerDelete(int id)
        {
            Model model = new Model();
            model = customerManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            Model model = new Model();
            model = customerManager.GetAllListBL();
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpPost]
        public IActionResult CustomerAdd([FromBody] Customer customer)
        {
            Model model = new Model();
            model = customerManager.InsertBL(customer);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpPut("Update")]
        public IActionResult CustomerUpdate([FromBody] Customer customer)
        {
            Model model = new Model();
            model = customerManager.UpdateBL(customer);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpPost("AddRange")]
        public IActionResult CustomerAddRange([FromBody] List<Customer> customers)
        {
            Model model = new Model();
            foreach (var item in customers)
            {
                model = customerManager.InsertBL(item);

                continue;
            }
            return Ok(model);
        }



        [HttpPost("AboneEkleme")]
        public IActionResult CustomerSubscribe(int id, List<Customer> customers)
        {
            Model model = new Model();
            bool evet = true;
            // customers = customerManager.GetAllListBL();
            foreach (var customer in customers)
            {
                if (customer.CustomerId == id && customer.Subscriber == false)
                {

                    if (evet = true)
                    {
                        customer.Subscriber = true;
                        customerManager.UpdateBL(customer);
                        model.models = customer;
                    }

                }
            }
            return Ok(model);
        }

        [HttpPut("Aboneiptal")]
        public IActionResult CustomerSubscribeDisable(int id, List<Customer> customers)
        {
            Model model = new Model();
            bool evet = true;
            foreach (var customer in customers)
            {
                if (customer.CustomerId == id && customer.Subscriber == true)
                {
                    //Abonelikten Çıkmak 
                    if (evet)
                    {
                        customer.Subscriber = false;
                        customerManager.UpdateBL(customer);
                        model.models = customer;
                    }
                }
            }
            return Ok(model);
        }

    }
}
