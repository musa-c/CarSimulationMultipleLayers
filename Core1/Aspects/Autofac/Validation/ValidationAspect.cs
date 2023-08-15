using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception // ValidationAspect bir attribute'dir.
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            // gönderilen validatorType IValidator değilse exception fırlat.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            // invocation metot demektir.
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // reflection 
            // reflection, çalışma anında birşeyler yapmaya sağlıyor. 
            // Burada çalışma anında _validatorType'in  instance'sini(örn: CarValidator) oluşturuyoruz.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            // _validatorType'in(örn: CarValidator) (miras alıdğı sınıfı)baseType'ni bul onun generic argümanlarından ilkini bul. 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            // parametrelerini bul. ilgili metotun(örn: Add) parametrelerinin (örn: Car)entityType'a eşit olanu bul.
            // çünkü birden fazla parametre'de olabilir. Biz burada örnek olarak Car'ı validate yapmak istiyoruz.

            // birden fazla örn car tipinde paramere varsa hepsiniz gez ValidateTool'u kullanarak validate et.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
