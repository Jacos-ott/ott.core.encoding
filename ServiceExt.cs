using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ott.core.encoding
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOTTDataExtension(this IServiceCollection services)
        {
            services.AddScoped<Encoding>();
            return services;
        }
    }
}
