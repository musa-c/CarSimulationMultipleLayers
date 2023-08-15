using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //builder.Services tooltip2inde IServiceCollection döndüğünü anladım buradan extension yaptım
        //extension metotu yazabilmek için class static olmak zorunda.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceColleciton, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceColleciton);
            }

            return ServiceTool.Create(serviceColleciton);
            // servisleri crate 
        }
    }
}
