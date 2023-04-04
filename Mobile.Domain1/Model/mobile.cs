using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain1.Model
{
    public class mobile
    {
        [Key]
        public int MobileId { get; set; }

        [Required]
        public string? MobileName { get; set; }

        [Required]
        public string? MobileModel { get; set; }

        [Range(0,999)]
        public int Quantity { get; set; }
        public int Price { get; set; }

        public DateTime Date { get; set; }

       [ForeignKey("customer")]

        public int Id { get; set; }

        public virtual customer? customer { get; set; }
    }
}
