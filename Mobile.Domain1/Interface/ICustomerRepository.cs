using Mobile.Domain1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain1.Interface
{
    public interface ICustomerRepository

    {
        Task<List<customer>> GetAllCustomerAsync();
        Task<customer> GetCustomerByIdAsync(int id);
        Task<customer> CreateCustomerAsync(customer customer);
        Task<customer> UpdateCustomerAsync(int id, customer mobile);
        Task<customer> DeleteCustomerAsync(int id);
       // Task<customer> GetCustomerByIdAsync(Mobile.Service1.Mapping.ServiceCustomerMapperList serviceCustomerMapperList);
      //  Task<customer> GetCustomerByIdAsync(Mobile.Service1.Model.Customer customer);
    }
}
