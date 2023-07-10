using Application.Interfaces;
using Core.Entities.InputModels;
using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ICommonUtil<Order> _commonUtil;

        public OrderRepository(ICommonUtil<Order> commonUtil)
        {
            _commonUtil = commonUtil;
        }

        public async Task<bool> CreateOrderAsync(Order info)
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
