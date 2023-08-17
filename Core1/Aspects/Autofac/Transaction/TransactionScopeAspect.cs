using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{ //aop
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using TransactionScope transactionScope = new();
            try
            {
                invocation.Proceed(); //invocation(metot) içidenki kod bloğunu çalıştır
                transactionScope.Complete();
            }
            catch (Exception e)
            {
                transactionScope.Dispose();
                throw;
            }
        }
    }
}
