
using HR_ManagmentClean.Application.Contracts.Email;
using HR_ManagmentClean.Application.Contracts.Logging;
using HR_ManagmentClean.Application.Models.Email;
using HR_ManagmentClean.Infrastructure.EmailService;
using HR_ManagmentClean.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean_Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services
            ,IConfiguration configuration) 
        {

            services.Configure<EmailSettings>(configuration.GetSection(key: "EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
        
    }
}
