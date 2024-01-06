using MashinAl.Data.Persistences;
using MashinAl.Infastructure.Commons.Abstracts;
using MashinAl.Infastructure.Entities.Membership;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MashinAl.Data
{
    public static class DataServiceInjection 
    {
        public static IServiceCollection InstallDataServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DbContext, DataContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });

            services.AddIdentityCore<MashinAlUser>()
                .AddRoles<MashinAlRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();


            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<UserManager<MashinAlUser>>();
            services.AddScoped<RoleManager<MashinAlRole>>();
            services.AddScoped<SignInManager<MashinAlUser>>();


            //var repoInterfaceType = typeof(IRepository<>);

            //var abstractRepositoryAssembly = repoInterfaceType.Assembly;
            //var concrateRepositoryAssembly = typeof(DataServiceInjection).Assembly;



            //foreach (var item in abstractRepositoryAssembly.GetTypes().Where(m => m.IsInterface
            //&& ((TypeInfo)m).ImplementedInterfaces.Any(x => x.Name.Equals("IRepository`1"))
            //))
            //{
            //    var concrateRepositories = concrateRepositoryAssembly.GetTypes()
            //        .FirstOrDefault(m => m.IsClass && typeof(IMarkaRepository).IsAssignableFrom(m));
            //    Console.WriteLine($"{item.Name} >> {concrateRepositories.Name}");

            //    if (concrateRepositories != null ) 
            //    services.AddScoped(item, concrateRepositories);
            //}
            //return services;

            var repoInterfaceType = typeof(IRepository<>);

            var concretRepositoryAssembly = typeof(DataServiceInjection).Assembly;

            var repositoryPairs = repoInterfaceType.Assembly
                                     .GetTypes()
                                     .Where(m => m.IsInterface
                                             && m.GetInterfaces()
                                                 .Any(i => i.IsGenericType
                                                     && i.GetGenericTypeDefinition() == repoInterfaceType))
                                     .Select(m => new
                                     {
                                         AbstactRepository = m,
                                         ConcrateRepository = concretRepositoryAssembly.GetTypes()
                                                              .FirstOrDefault(r => r.IsClass && m.IsAssignableFrom(r)),
                                     })
                                     .Where(m => m.ConcrateRepository != null);

            foreach (var item in repositoryPairs)
            {
                services.AddScoped(item.AbstactRepository, item.ConcrateRepository!);
            }
            return services;
        }
        
    }
}
