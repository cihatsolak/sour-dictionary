namespace SourDictionary.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SourDictionaryContext>(config =>
            {
                config.UseNpgsql(configuration.GetConnectionString("SourDictionaryDbConnectionString"), opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            return services;
        } 
    }
}
