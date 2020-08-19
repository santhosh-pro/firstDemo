using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutoMapper;
using firstDemo.Common.Abstractions;
using Module = Autofac.Module;

namespace firstDemo.Common.Helpers.Extensions
{
    public class AppDI : Module
    {
        private readonly Assembly[] _assemblies;

        public AppDI(Assembly[] assemblies)
        {
            _assemblies = assemblies;
        }

        public AppDI() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Auto Mapper
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                //cfg.ConstructServicesUsing( ServiceConstructor );

                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            }))
                .AsSelf()
                .AutoActivate()
                .SingleInstance();

            builder.Register(c =>
            {
                // these are the changed lines
                var scope = c.Resolve<ILifetimeScope>();
                return new Mapper(c.Resolve<MapperConfiguration>(), scope.Resolve);
            })
                .As<IMapper>()
                .SingleInstance();


            // Persistense
            builder.RegisterGeneric(typeof(PagingRepository<,>)).As(typeof(IPagingRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EntityRepository<,>)).As(typeof(IEntityRepository<,>)).InstancePerLifetimeScope();
        }
    }
}