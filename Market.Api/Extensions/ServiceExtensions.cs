using Market.Data.IRepositories;
using Market.Data.Repositories;
using Market.Service.Interfaces;
using Market.Service.Services;

namespace Market.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCostumServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
        }
    }
}
