
using Application.Interfaces;

namespace InfraStructure.Repository
{
    public class UnitWork : IUnitWork
    {
        public ILoginRepository login { get; }
        public IEVoucherRepository eVoucher { get; }
        public IBuyEVoucherRepository buyEVoucher { get; }
        public IPaymentRepository payment { get; }
        public IOrderRepository order { get; }
        public ITransactionRepository transaction { get; }
        public IPromotionRepository promotion { get; }  

        public UnitWork(ILoginRepository loginRepository, IEVoucherRepository eVoucherRepository, IBuyEVoucherRepository buyEVoucherRepository,
            IPaymentRepository paymentRepository, IOrderRepository orderRepository, ITransactionRepository transactionRepository, IPromotionRepository promotionRepository)
        {
            login = loginRepository;
            eVoucher = eVoucherRepository;
            buyEVoucher = buyEVoucherRepository;
            payment = paymentRepository;
            order = orderRepository;
            transaction = transactionRepository;
            promotion = promotionRepository;
        }

    }
}
