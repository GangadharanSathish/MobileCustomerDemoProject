using Mobile.Domain1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Service1.Interface
{
    public interface IMobileService
    {

        Task<List<mobile>> GetAllMobileAsync();
        Task<mobile> GetMobileByIdAsync(int id);
        Task<mobile> CreateMobileAsync(mobile request);
        Task<mobile> UpdateMobileAsync(int id, mobile mobile);
        Task<mobile> DeleteMobileAsync(int id);
    }
}
