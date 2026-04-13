using Microsoft.AspNetCore.Mvc;
using SS.Api.Models.Common;

namespace SS.Api.Extensions
{
    static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .SelectMany(x => x.Value!.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    var response = ApiResponse<object>.Fail(errors, "Erro de validação.");

                    return new BadRequestObjectResult(response);
                };
            });

            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}
