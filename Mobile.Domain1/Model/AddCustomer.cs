using System;
using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain1.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class AddCustomer
    {
        public int MobileId { get; set; }
        public string? MobileName { get; set; }
        public string? MobileModel { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }
    }
}
