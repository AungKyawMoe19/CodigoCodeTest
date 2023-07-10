using Core.Entities.InputModels;
using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEVoucherRepository
    {
        Task<IReadOnlyList<Evoucher>> GetAllEVouchers();
        Task<Evoucher> GetEVoucherById(string id);
        Task<bool> CreateEVoucherAsync(EVoucherModel info);
        Task<bool> UpdateEVoucherAsync(string id, Evoucher _evoucher);
        Task<bool> DeleteEVoucher(string id);
    }
}
