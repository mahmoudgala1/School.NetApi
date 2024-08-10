using Microsoft.Extensions.DependencyInjection;
using School.Service.Implementation;
using School.Service.Interfaces;

namespace School.Service;
public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();
        return services;
    }
}
