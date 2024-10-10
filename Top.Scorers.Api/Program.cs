using Microsoft.EntityFrameworkCore;
using Top.Scorers.Data;
using Top.Scorers.Data.Contexts;
using Top.Scorers.Domain.IoC;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ConfigureDb(builder.Services);
        AddServices(builder.Services);
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    static void AddServices(IServiceCollection services)
    {
        services.AddDomainServices();
    }

    public static void ConfigureDb(IServiceCollection services)
    {
        services.AddDbContext<PersonDbContext>(options =>
        options.UseSqlite("Data Source=PersonDatabase.db"));
        services.AddTransient<PersonRepository>();
    }
}