using Microsoft.EntityFrameworkCore;
using Mobile.Domain1.Data;
using Mobile.Domain1.Interface;
using Mobile.Domain1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain1.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MobileDbContext _context;
        public CustomerRepository(MobileDbContext context)
        {
            _context = context;
        }
        public async Task<customer> CreateCustomerAsync(customer customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<customer> DeleteCustomerAsync(int id)
        {
            var customer = _context.customers.FirstOrDefault(customer => customer.Id == id);
            _context.customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }



        //public async Task<customer> DeleteCustomerAsync(int id)
        //{
        //    var customer = await _context.customers.FirstOrDefaultAsync(customer => customer.Id == id);
        //    //if (customers == null)
        //    //    return Bad("No result found");
        //    _context.customers.Remove(customer);
        //    await _context.SaveChangesAsync();
        //    return customer;
        //}


      


        public async Task<List<customer>> GetAllCustomerAsync()
        {
            return await _context.customers.ToListAsync();
        }

  

        public async Task<customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.customers.FirstOrDefaultAsync(customer => customer.Id == id);
            if (customer != null)

                _context.Entry(customer).State = EntityState.Detached;
            
            
            return customer;

           if (customer== null)
                return null;


      
        }



        public async Task<customer> UpdateCustomerAsync(int id, customer customer)
        {
            var Customer = await _context.customers.FirstOrDefaultAsync(customer => customer.Id == id);
            Customer.CustomerName = customer.CustomerName;
            Customer.Gender = customer.Gender;
            Customer.Email = customer.Email;
            Customer.Password = customer.Password;
            Customer.PhoneNumber = customer.PhoneNumber;
            Customer.Address = customer.Address;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
    //public class CustomerRepository : ICustomerRepository
    //{
    //    private readonly MobileDbContext _mobileDb;
    //    public CustomerRepository(MobileDbContext mobileDb)
    //    {
    //        _mobileDb = mobileDb;
    //    }
    //    public async Task<customer> CreateCustomerAsync(customer mobile)
    //    {
    //        await _mobileDb.customers.AddAsync(mobile);
    //        await _mobileDb.SaveChangesAsync();
    //        return mobile;
    //    }

    //    public async Task<customer> DeleteCustomerAsync(int id)
    //    {
    //        var customer = await _mobileDb.customers.FirstOrDefaultAsync(customers => customers.Id == id);
    //        _mobileDb.customers.Remove(customer);
    //        await _mobileDb.SaveChangesAsync();
    //        return customer;
    //    }
    //        public async Task<List<customer>> GetAllCustomerAsync()
    //    {
    //        return await _mobileDb.customers.ToListAsync();
    //    }

    //    public async Task<customer> GetCustomerByIdAsync(int id)
    //    {
    //        var customer = await _mobileDb.customers.FirstOrDefaultAsync(customers => customers.Id == id);
    //        return customer;
    //    }

    //    public async Task<customer> UpdateCustomerAsync(int id, customer mobile)
    //    {
    //        var customer = await _mobileDb.customers.FirstOrDefaultAsync(customers => customers.Id == id);

    //        customer.CustomerName = mobile.CustomerName;
    //        customer.Email = mobile.Email;
    //        customer.Password = mobile.Password;
    //        customer.PhoneNumber = mobile.PhoneNumber;
    //        customer.Address = mobile.Address;

    //        await _mobileDb.SaveChangesAsync();
    //        return customer;
    //    }
   

