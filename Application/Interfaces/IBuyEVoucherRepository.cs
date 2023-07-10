using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBuyEVoucherRepository
    {
        Task<bool> CreateBuyEVoucherAsync(Buyevoucher info);
        Task<bool> ModTenCheck(string cardNumber);
    }
}
