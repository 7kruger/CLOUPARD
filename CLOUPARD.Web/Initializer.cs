using CLOUPARD.BLL.Interfaces;
using CLOUPARD.BLL.Services;
using CLOUPARD.DAL.Entities;
using CLOUPARD.DAL.Interfaces;
using CLOUPARD.DAL.Repositories;
using CLOUPARD.Web.Services.Implementations;
using CLOUPARD.Web.Services.Interfaces;

namespace CLOUPARD.Web;

public static class Initializer
{
    public static void InitializeRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Product>, ProductRepository>();
    }

    public static void InitializeServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IIndexPageService, IndexPageService>();
    }
}
