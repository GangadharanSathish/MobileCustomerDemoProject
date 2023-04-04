using AutoMapper;
using Mobile.Domain1.Model;
//using Mobile.Service1.Mapping;
//using Mobile.Domain1.Mapping;
using Mobile.Service1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Service1.AutoMapper
{
    public class CustomerServiceMapping : Profile
    {
        public CustomerServiceMapping()
        {
            CreateMap<customer, Customer>();

        }

    }
}
