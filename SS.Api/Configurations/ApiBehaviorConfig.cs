using Microsoft.AspNetCore.Mvc;

namespace SS.Api.Configurations
{
    public static class ApiBehaviorConfig
    {
        public static IServiceCollection AddApiBehaviorConfiguration(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
            });

            return services;
        }
    }
}
