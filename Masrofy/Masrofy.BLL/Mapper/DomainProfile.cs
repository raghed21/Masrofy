using AutoMapper;
using Masrofy.BLL.Models;
using Masrofy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Initialize mappings here
            // For example:
            // CreateMap<SourceType, DestinationType>();
            CreateMap<ExpenseVM, Expense>();
            CreateMap<Expense, ExpenseVM>();

        }
    }
}
