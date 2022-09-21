using Microsoft.Extensions.DependencyInjection;
using Service.Implementation;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService,EmailService>();
            return services;
        }
    }
}
