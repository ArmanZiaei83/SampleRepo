using Infrastructure.Data.DbContext;
using Infrastructure.Data.Repositories.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Contracts.Repositories;
using Sample.Application.Contracts.Services;
using Sample.Application.Services.Students;

namespace Sample.Infrastructure.Dependency
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<IStudentRepository, StudentRepository>();

            service.AddDbContext<EFDataContext>
            (_ => _.UseSqlServer(
                "Server=.;Database=SampleApp-Test;Trusted_Connection=True;"));
        }
    }
}