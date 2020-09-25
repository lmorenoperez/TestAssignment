using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Models;

namespace TestAssignment.Services
{
    public interface ITaxService
    {
        Task<TaxRateModel> GetRate(string city);
    }
}
