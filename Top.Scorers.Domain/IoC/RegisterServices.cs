using Microsoft.Extensions.DependencyInjection;
using Top.Scorers.Data;
using Top.Scorers.Domain.Interfaces;
using Top.Scorers.Domain.Services;

namespace Top.Scorers.Domain.IoC
{
    public static class RegisterServices
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ICsvHandler>(x=> new CsvHandler("TestData.csv"));
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonRepository, PersonRepository>();
        }
    }
}
