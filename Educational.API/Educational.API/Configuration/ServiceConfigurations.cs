
using Educational.Data.MappingProfiles;
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
            services.AddAutoMapper(typeof(MappingProfiles));
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>(); 
            serviceCollection.AddScoped<ICourseDetailRepository , CourseDetailRepository>();
            serviceCollection.AddScoped<ITutorRepository, TutorRepository>();
            serviceCollection.AddTransient<IReviewRepository, ReviewRepository>();
            serviceCollection.AddScoped<ICouponRepository, CouponRepository>();
            serviceCollection.AddScoped<ICountryRepository, CountryRepository>();
            serviceCollection.AddScoped<IStateRepository, StateRepository>();
            serviceCollection.AddScoped<ICityRepository, CityRepository>();


        }
    }
}
