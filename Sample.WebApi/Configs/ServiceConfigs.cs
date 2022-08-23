using System;
using System.IO;
using Autofac;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories.Teachers;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Sample.Application.Interfaces;
using Sample.Application.Interfaces.Repositories;
using Sample.Application.Interfaces.Services;
using Sample.Application.Teachers;

namespace Sample.WebApi.Configs
{
    public class ServiceConfigs : Module
    {
        private readonly string? _dbConnectionString;

        public ServiceConfigs()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var isDevelopment =
                Convert.ToBoolean(configuration["IsDevelopment"]);

            _dbConnectionString = isDevelopment
                ? configuration["ConnectionString"]
                : Environment.GetEnvironmentVariable("CONNECTION_STRING");
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
                .WithParameter("connectionString", _dbConnectionString)
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