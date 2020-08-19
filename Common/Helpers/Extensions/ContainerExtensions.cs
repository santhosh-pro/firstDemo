using Autofac;

namespace firstDemo.Common.Helpers.Extensions
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder AddApplicationDI (this ContainerBuilder builder) {
            builder.RegisterModule (new AppDI());
            return builder;
        }
    }
}