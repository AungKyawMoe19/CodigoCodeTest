using Application.Interfaces;
using Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository
{
    public class PaymentRepository : CommonUtil<Buyevoucher>, IPaymentRepository
    {
        private readonly ICommonUtil<Payment> _commonUtil;

        public PaymentRepository(ICommonUtil<Payment> commonUtil, CodetestContext context) : base(context)
        {
            _commonUtil = commonUtil;
        }

        public  Task<Payment> GetPayment(string method)
        {
            return _context.Payments.FirstOrDefaultAsync(s => s.PaymentType == method);
        }

        public async Task<bool> CreatePaymentAsync(Payment info)
        {
            try
            {
                await _commonUtil.AddAsync(info);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
