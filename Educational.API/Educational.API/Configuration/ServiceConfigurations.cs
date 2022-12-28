using Educational.Data.Repositories;
using Educational.DataContracts.IRepositories;

namespace Educational.API.Configuration
{
    public static  class ServiceConfigurations
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
         
        }
    }
}
