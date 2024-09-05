using Microsoft.Extensions.DependencyInjection;
using School.Infrustructure.Interfaces;
using School.Infrustructure.Repositories;

namespace School.Infrustructure;
public static class ModuleInfrustructureDependencies
{
    public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        return services;
    }
}
