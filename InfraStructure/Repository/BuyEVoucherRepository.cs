using Application.Interfaces;
using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Core.Entities.InputModels;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repository
{
    public class BuyEVoucherRepository : CommonUtil<Buyevoucher>,IBuyEVoucherRepository
    {
        private readonly ICommonUtil<Buyevoucher> _commonUtil;

        public BuyEVoucherRepository(ICommonUtil<Buyevoucher> commonUtil, CodetestContext context) : base(context)
        {
            _commonUtil = commonUtil;
        }

        public async Task<bool> CreateBuyEVoucherAsync(Buyevoucher info)
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
        

        //public static byte[] byteArray(Bitmap bitmap)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitmap.Save(ms, ImageFormat.Png);
        //        return ms.ToArray();
        //    }
        //}

        

        public async Task<bool> ModTenCheck(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }
            int sumOfDigits = cardNumber.Where((e) => e >= '0' && e <= '9').Reverse().Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2)).Sum((e) => e / 10 + e % 10);
            return sumOfDigits % 10 == 0;
        }
    }
}
