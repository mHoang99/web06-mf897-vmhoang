using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.API
{
    public class NullObjectModelValidator : IObjectModelValidator
    {
        public void Validate(ActionContext actionContext,
            ValidationStateDictionary validationState, string prefix, object model)
        {

        }
    }

    public static class ExtensionMethodClass
    {
        public static IServiceCollection DisableDefaultModelValidation(this IServiceCollection services)
        {
            ServiceDescriptor serviceDescriptor = services.FirstOrDefault<ServiceDescriptor>((Func<ServiceDescriptor, bool>)(s => s.ServiceType == typeof(IObjectModelValidator)));
            if (serviceDescriptor != null)
            {
                services.Remove(serviceDescriptor);
                services.Add(new ServiceDescriptor(typeof(IObjectModelValidator), (Func<IServiceProvider, object>)(_ => (object)new NullObjectModelValidator()), ServiceLifetime.Singleton));
            }
            return services;
        }
    }
}
