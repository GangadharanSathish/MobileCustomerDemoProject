using Mobile.Domain1.Model;
using Mobile.Service1.Model;
//using MobileDemoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Service1.Interface
{
    public interface ICustomerService
    {
        // Task<List<CustomerMobile>> GetAllCustomerAsync();

        Task<List<Customer>> GetAllCustomerAsync();
        Task<customer> GetCustomerByIdAsync(int id);
        Task<customer> CreateCustomerAsync(customer customer);
        Task<customer> UpdateCustomerAsync(int id, customer mobile);
        Task<customer> DeleteCustomerAsync(int id);

    }
}
