using System.IO;
using Autofac;
using Infrastructure.Persistence.DbContext;
using Infrastructure.Persistence.Repositories.Students;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Sample.Application.Contracts.Repositories;
using Sample.Application.Contracts.Services;
using Sample.Application.Students;

namespace Sample.WebApi.Configs
{
    public class ServicesModule : Module
    {
        private readonly IConfigurationRoot _configuration;

        public ServicesModule()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>()
                .As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>()
                .As<IStudentService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EFDataContext>()
                .WithParameter("connectionString",
                    _configuration["ConnectionString"])
                .AsSelf()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}