using D2RDropCalc.Server.Api.Lib;
using D2RDropCalc.Server.Services;
using D2RDropCalc.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace D2RDropCalc.Server.Lib.Extensions
{
    public static class InjectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
