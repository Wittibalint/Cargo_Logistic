using Logistic.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LogisticServiceExtensions
    {
        public static IServiceCollection AddLogisticService(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ILogisticService), typeof(LogisticService), serviceLifetime));
            return services;
        }
    }
}
