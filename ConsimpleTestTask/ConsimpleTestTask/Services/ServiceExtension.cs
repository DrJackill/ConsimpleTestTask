namespace ConsimpleTestTask.Services
{
    public static class ServiceExtansion
    {
        public static void ConfigureModelServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchasesService, PurchasesService>();
        }
    }
}