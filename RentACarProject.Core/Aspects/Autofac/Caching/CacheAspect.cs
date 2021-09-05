using System.Linq;
using RentACarProject.Core.CrossCuttingConcerns.Caching;
using RentACarProject.Core.Utilities.Interceptors;
using RentACarProject.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace RentACarProject.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private readonly int _duration;

        public CacheAspect(int duration)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); //örn: ICarService.GetById
            var arguments = invocation.Arguments.ToList(); //örn: id, colorName vb. (parametre varsa)
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //örn: ICarService.GetById(1) veya ICarService.GetById(<Null>)

            if (_cacheManager.IsAdded(key)) //daha önce cache'e eklenmiş mi?
            {
                invocation.ReturnValue = _cacheManager.Get(key); //eklenmişse direk hazırı ver
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //eklenmemişse cache'e ekle
        }
    }
}
