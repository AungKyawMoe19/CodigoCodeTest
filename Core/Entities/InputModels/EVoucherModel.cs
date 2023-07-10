using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.InputModels
{
    public class EVoucherModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public byte[] Image { get; set; }
        public double Amount { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public int MaxEVoucher { get; set; }
        public int MaxGiftEVoucher { get; set; }

    }

    public class BuyEVoucherModel
    {
        public string EVoucherId { get; set; }
        public string PaymentMethod { get; set; }
        public string BuyMethod { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionId { get; set; }
        public string CardNumber { get; set; }
        public int Quantity { get; set; }
    }

    public class CodeMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
    
    public class PaymentModel
    {
        public string paymentType { get; set; }
    }

    public enum Discount
    {
        VISA = 10
    }
}
