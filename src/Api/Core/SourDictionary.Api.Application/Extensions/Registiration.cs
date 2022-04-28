namespace SourDictionary.Api.Application.Extensions
{
    public static class Registiration
    {
        public static IServiceCollection AddApplicationRegistiration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
