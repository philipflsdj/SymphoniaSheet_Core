using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SS.Application.Configurations.AutoMapper;
using SS.Application.Configurations.Interfaces;
using SS.Application.Configurations.Notificacoes;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Contracts.Services;
using SS.Persistence.Contexts;
using SS.Persistence.Repositories;
using SS.Persistence.Services;
using SS.Persistence.Services.Identity;

namespace SS.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SymphoniaSheetDbContext>(options =>
                options.UseSqlServer(connectionString));

            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<SymphoniaSheetDbContext>()
                .AddDefaultTokenProviders();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionConfig).Assembly));
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile).Assembly);
            services.AddValidatorsFromAssembly(typeof(DependencyInjectionConfig).Assembly);

            services.AddScoped<AppNotificationHandler>();
            services.AddScoped<INotificationHandler>(sp => sp.GetRequiredService<AppNotificationHandler>());
            services.AddScoped<MediatR.INotificationHandler<AppNotification>>(sp => sp.GetRequiredService<AppNotificationHandler>());
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            services.AddScoped<IInstrumentoRepository, InstrumentoRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPartituraRepository, PartituraRepository>();
            services.AddScoped<IFavoritoRepository, FavoritoRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<IRepertorioRepository, RepertorioRepository>();

            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUploadArquivoService, UploadArquivoLocalService>();

            return services;
        }
    }
}
