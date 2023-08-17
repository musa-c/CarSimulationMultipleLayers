using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) // 60dk boyunca cache'de duracak.
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>()!;
            // aspect olduğu için enjection yapılamaz.
        }

        //getAll çelışmadan bu kodlar çalışır
        //OnBefore'de olabilirdi farketmez.
        public override void Intercept(IInvocation invocation)
        {
           
            //Northwind.Business.ICarService.GetAll
            var methodName = string.Format($"{invocation.Method.ReflectedType!.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key)) 
            {
                // invocation.ReturnValue -> metotu hiç çalıştırmadan geri dön. manuel bir return oluşturuk.
                invocation.ReturnValue = _cacheManager.Get(key);
                // invocation.ReturnValue-> metotun return değeri  _cacheManager.Get(key) olsun.
                return;
            }
            invocation.Proceed(); // yoksa invocation'i devam ettir. metotu çalıştırır??
            _cacheManager.Add(key, invocation.ReturnValue, _duration); 

        }
    }
}