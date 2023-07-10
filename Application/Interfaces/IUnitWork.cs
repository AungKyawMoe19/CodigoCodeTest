
namespace Application.Interfaces
{
    public interface IUnitWork
    {
        ILoginRepository login { get; }
        IEVoucherRepository eVoucher { get; }
        IBuyEVoucherRepository buyEVoucher { get; }
        IPaymentRepository payment { get; }
        IOrderRepository order { get; }
        ITransactionRepository transaction { get; }
        IPromotionRepository promotion { get; }
    }
}
