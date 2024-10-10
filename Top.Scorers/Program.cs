using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Top.Scorers.Domain.IoC;
using Top.Scorers.Domain.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                AddServices(services);
            }).Build();

        var personService = host.Services.GetService<IPersonService>();
        
        Console.WriteLine("----Top Scorers App----");
        Console.WriteLine("Top Scorers are:");
        Console.WriteLine(personService.PrintTop());
        
        Console.ReadLine();
    }

    static void AddServices(IServiceCollection services)
    {
        services.AddDomainServices();
    }
}