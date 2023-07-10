using Application.Interfaces;
using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly ICommonUtil<Transaction> _commonUtil;

        public TransactionRepository(ICommonUtil<Transaction> commoUtil)
        {
            _commonUtil = commoUtil;
        }

        public async Task<bool> CreateTransactionAsync(Transaction info)
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
