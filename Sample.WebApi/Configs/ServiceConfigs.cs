using System.IO;
using Autofac;
using Infrastructure.Persistence.DbContext;
using Infrastructure.Persistence.Repositories.Teachers;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Sample.Application.Contracts;
using Sample.Application.Contracts.Repositories;
using Sample.Application.Contracts.Services;
using Sample.Application.Teachers;

namespace Sample.WebApi.Configs
{
    public class ServiceConfigs : Module
    {
        private readonly IConfigurationRoot _configuration;

        public ServiceConfigs()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(TeacherService).Assembly)
                .AssignableTo<IService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(TeacherRepository).Assembly)
                .AssignableTo<IRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<EFDataContext>()
                .WithParameter("connectionString",
                    _configuration["ConnectionString"])
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<EFUnitOfWork>()
                .As<IUnitOfWork>()
                .AsSelf()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}