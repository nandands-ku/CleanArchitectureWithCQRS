using MediatR;
using System.Reflection;

namespace DiziCashier.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //public static IServiceCollection AddHandlers(this IServiceCollection services, Assembly assembly)
        //{
        //    services.AddHandlers(typeof(IRequestHandler<,>), assembly);

        //    return services;
        //}

        //private static void AddHandlers(this IServiceCollection services, Type handlerType, Assembly assembly)
        //{
        //    foreach (var type in assembly.GetTypes())
        //    {
        //        if (type.IsConcrete() && type.CanBeCastTo(handlerType))
        //        {
        //            services.AddScoped(type.GetHandlerInterface(handlerType), type);
        //        }
        //    }
        //}

        //private static bool IsConcrete(this Type type)
        //{
        //    return !type.IsAbstract &&


        //        }



    }
}
