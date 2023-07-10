using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<bool> CreateTransactionAsync(Transaction info);
    }
}
