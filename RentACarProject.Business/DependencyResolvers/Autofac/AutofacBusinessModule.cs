using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using RentACarProject.Business.Abstract;
using RentACarProject.Business.Concrete;
using RentACarProject.Core.Utilities.Interceptors;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;

namespace RentACarProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() })
                .SingleInstance();
        }
    }
}
