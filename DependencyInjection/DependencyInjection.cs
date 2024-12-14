using EmailSender.Api.Models;
using EmailSenderApi.Service;

namespace EmailSenderApi.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(
       this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
