using System;
using Microsoft.AspNetCore.Http;
using RentACarProject.Core.Utilities.Interceptors;
using RentACarProject.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using RentACarProject.Core.Extensions;
using RentACarProject.Business.Constants;

namespace RentACarProject.Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string[] _roles;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.serviceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimsRoles();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role)) return;
            }

            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
