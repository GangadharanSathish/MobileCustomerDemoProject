using Azure.Core;
using Microsoft.AspNetCore.Mvc;
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
    public class MobileRepository : IMobileRepository
    {
        private readonly MobileDbContext _context;



        public MobileRepository(MobileDbContext context)
        {
            _context = context;
        }



        public async Task<mobile> CreateMobileAsync(mobile request)
        {
            var Customer = await _context.customers.FindAsync(request.Id);
            if (Customer == null)
            { return null; }

            var AddMobile = new mobile()
            {
                MobileName = request.MobileName,
                MobileModel = request.MobileModel,
                Quantity = request.Quantity,
                Price = request.Price,
                Date = request.Date,
                Id = request.Id,
                customer = Customer

            };
            _context.mobiles.Add(AddMobile);
            await _context.SaveChangesAsync();
            return AddMobile;


        }


        //public async Task<ActionResult<List<mobile>>> CreateMobileAsync(mobile Request)
        //{
        //    var Customers = await _context.mobiles.FindAsync(Request.MobileId);
        //    if (Customers == null)
        //        return NotFound();



        //        var newmobiles = new mobile
        //        {
        //        MobileId = Request.MobileId,
        //        MobileName = Request.MobileName,
        //        MobileModel = Request.MobileModel,
        //        Quantity = Request.Quantity,
        //        Price = Request.Price,
        //        Date = Request.Date,
        //        customer = Customers
        //        };



        //    _context.mobiles.Add(newmobiles);
        //    await _context.SaveChangesAsync();
        //    return Ok(newmobiles);
        //}
        //public async Task<AddMobile> CreateMobileAsync(AddMobile addMobile)
        //{
        //    _context.mobiles.Add(addMobile);
        //    await _context.SaveChangesAsync();
        //    return addMobile;
        //}



        public async Task<mobile> DeleteMobileAsync(int id)
        {
            var mobile = await _context.mobiles.FirstOrDefaultAsync(mobile => mobile.MobileId == id);
            _context.mobiles.Remove(mobile);
            await _context.SaveChangesAsync();
            return mobile;
        }



        public async Task<List<mobile>> GetAllMobileAsync()
        {
            return await _context.mobiles.ToListAsync();
        }



        public async Task<mobile> GetMobileByIdAsync(int id)
        {
            var mobile = await _context.mobiles.Include(x=>x.customer).FirstOrDefaultAsync(mobile => mobile.MobileId == id);
               return mobile;
        }



        public async Task<mobile> UpdateMobileAsync(int id, mobile mobile)
         {
            var Mobile = await _context.mobiles.FirstOrDefaultAsync(mobile => mobile.MobileId == id);
            Mobile.MobileName = mobile.MobileName;
            Mobile.MobileModel = mobile.MobileModel;
            Mobile.Quantity = mobile.Quantity;
            Mobile.Price = mobile.Price;

            await _context.SaveChangesAsync();
            return Mobile;
        }
    }
}

//    public class MobileRepository : IMobileRepository
//    {
//        private readonly MobileDbContext _mobileDb;
//        public MobileRepository(MobileDbContext mobileDb)
//        {
//            _mobileDb = mobileDb;
//        }

//        public async Task<mobile> CreateMobileAsync(mobile mobile)
//        {
//           await _mobileDb.mobiles.AddAsync(mobile);
//            await _mobileDb.SaveChangesAsync();
//            return mobile;
//        }

//        public async Task<mobile> DeleteMobileAsync(int id)
//        {
//            var mobile = await _mobileDb.mobiles.FirstOrDefaultAsync(mobiles => mobiles.MobileId == id);
//            _mobileDb.mobiles.Remove(mobile);
//            await _mobileDb.SaveChangesAsync();
//            return mobile;
//        }

//        public async Task<List<mobile>> GetAllMobileAsync()
//        {
//            return await _mobileDb.mobiles.ToListAsync();
//        }

//        public async Task<mobile> GetMobileByIdAsync(int id)
//        {
//            var mobile = await _mobileDb.mobiles.FirstOrDefaultAsync(mobiles => mobiles.MobileId == id);
//            return mobile;
//        }

//        public async Task<mobile> UpdateMobileAsync(int id, mobile mobile)
//        {
//            var Mobile = await _mobileDb.mobiles.FirstOrDefaultAsync(mobiles => mobiles.MobileId == id);

//            Mobile.MobileName = mobile.MobileName;
//            Mobile.MobileModel = mobile.MobileModel;
//            Mobile.Quantity = mobile.Quantity;
//            Mobile.Price = mobile.Price;
//            Mobile.Date = mobile.Date;

//            await _mobileDb.SaveChangesAsync();
//            return Mobile;

//        }
//    }
//}
