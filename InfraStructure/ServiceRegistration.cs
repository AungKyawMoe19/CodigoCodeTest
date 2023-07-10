using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using InfraStructure.Repository;

namespace InfraStructure
{
    public static class ServiceRegistration
    {
        public static void AddInfraStructure(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICommonUtil<>), typeof(CommonUtil<>));
            services.AddTransient<IUnitWork, UnitWork>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IEVoucherRepository, EVoucherRepository>();
            services.AddTransient<IBuyEVoucherRepository, BuyEVoucherRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IPromotionRepository, PromotionRepository>();           
            services.AddScoped<IEVoucherRepository, EVoucherRepository>();
            services.AddScoped<IBuyEVoucherRepository, BuyEVoucherRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
        }
    }
}
