using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //MethodInterceptionBaseAttribute'e sahip (class)type'nin attribute'lerini döndürür.
            // true ise properties ve event'lerde dahil edilir. False ise göz ardı edilir.
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //örn: Add metotunda sadece MethodInterceptionBaseAttribute özniteliğine sahip attribute'yi dödürür.
            // true ise properties ve event'lerde dahil edilir. False ise göz ardı edilir.
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
