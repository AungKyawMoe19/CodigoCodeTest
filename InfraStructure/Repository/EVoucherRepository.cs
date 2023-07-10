using Application.Interfaces;
using Core.Entities.InputModels;
using Core.Entities.Models;
using Google.Protobuf.Reflection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InfraStructure.Repository
{
    public class EVoucherRepository : CommonUtil<Evoucher>,IEVoucherRepository
    {
        private ICommonUtil<Evoucher> _commonUtil;
        public EVoucherRepository(ICommonUtil<Evoucher> commonUtil, CodetestContext context) : base(context)
        {
            _commonUtil = commonUtil;
        }

        public async Task<IReadOnlyList<Evoucher>> GetAllEVouchers()
        {
            return await _context.Evouchers.Where(x => x.Active == true).ToListAsync();
        }

        public async Task<Evoucher> GetEVoucherById(string id)
        {
            var result = await GetAllEVouchers();
            return result.Where(x => x.EVoucherId == id).FirstOrDefault();
        }

        public async Task<bool> CreateEVoucherAsync(EVoucherModel info)
        {
            try
            {
                Evoucher eVoucher = new Evoucher();
                eVoucher.EVoucherId = System.Guid.NewGuid().ToString();
                eVoucher.Active = true;
                eVoucher.CreatedBy = "admin";
                eVoucher.CreatedOn = DateTime.Now;
                eVoucher.ModifyOn = DateTime.Now;
                eVoucher.Title = info.Title;
                eVoucher.Description = info.Description;
                eVoucher.ExpiryDate = info.ExpiryDate;
                eVoucher.Image = info.Image;
                eVoucher.Amount = info.Amount;
                eVoucher.MaxEvoucher = info.MaxEVoucher;
                eVoucher.MaxGiftEvoucher = info.MaxGiftEVoucher;
                await _commonUtil.AddAsync(eVoucher);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> UpdateEVoucherAsync(string id, Evoucher _evoucher)
        {
            try
            {
                Evoucher evoucher = await _commonUtil.GetByIdAsync(id);
                if (evoucher != null)
                {
                    evoucher = _evoucher;
                    evoucher.ModifyBy = "admin";
                    evoucher.ModifyOn = DateTime.Now;
                }
                
                await _commonUtil.UpdateAsync(evoucher);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> DeleteEVoucherAsync(string id)
        {
            try
            {
                Evoucher evoucher = await _commonUtil.GetByIdAsync(id);
                await _commonUtil.DeleteAsync(evoucher);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> DeleteEVoucher(string id)
        {
            try
            {
                Evoucher evoucher = await _commonUtil.GetByIdAsync(id);
                if (evoucher != null)
                {
                    evoucher.Active = false;
                    evoucher.ModifyBy = "admin";
                    evoucher.ModifyOn = DateTime.Now;
                }
                await _commonUtil.UpdateAsync(evoucher);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
