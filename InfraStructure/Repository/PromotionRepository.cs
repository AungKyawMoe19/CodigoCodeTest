using Application.Interfaces;
using Core.Entities.InputModels;
using Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository
{
    public class PromotionRepository : CommonUtil<Promotion>, IPromotionRepository
    {
        private readonly ICommonUtil<Promotion> _commonUtil;
        int lengthOfVoucher = 11; int numeric = 6; int alphabet = 5;
        static Random random = new Random();
        public PromotionRepository(ICommonUtil<Promotion> commonUtil, CodetestContext context) : base(context)
        {
            _commonUtil = commonUtil;
        }

        public async Task<bool> CreatePromotionAsync(Promotion info)
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

        public Task<Promotion> GetPromotionByPromoCode(string pCode)
        {
            return _context.Promotions.FirstOrDefaultAsync(s => s.PromoCode == pCode);
        }

        public async Task<string> GeneratePromoCode()
        {
            char[] numerickeys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] alphabetkeys = "01234567890".ToCharArray();

            string promoCode =  Enumerable
            .Range(1, numeric) // for(i.. ) 
            .Select(k => numerickeys[random.Next(0, numerickeys.Length - 1)])  // generate a new random char 
            .Aggregate("", (e, c) => e + c) +
             Enumerable
            .Range(1, alphabet) // for(i.. ) 
            .Select(k => alphabetkeys[random.Next(0, alphabetkeys.Length - 1)])  // generate a new random char 
            .Aggregate("", (e, c) => e + c); // join into a string

            //Check Duplicate PromoCode
            var promotion = await GetPromotionByPromoCode(promoCode);
            if (promotion == null) return promoCode;
            return await GeneratePromoCode();
        }
    }
}
