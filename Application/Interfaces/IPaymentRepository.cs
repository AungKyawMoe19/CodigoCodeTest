using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPayment(string method);
        Task<bool> CreatePaymentAsync(Payment info);
    }
}
