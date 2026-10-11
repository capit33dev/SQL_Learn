using SqlProject.BLL;
using SqlProject.DAL;
using SqlProject.Interfaces.Managers;
using SqlProject.Interfaces.Repository;
using System;

namespace SqlProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        RegisterManagers(builder.Services);
        RegisterRepositories(builder.Services);





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

    private static void RegisterManagers(IServiceCollection services)
    {
        services.AddScoped<ITestManager, TestManager>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IActorRepository, ActorRepository>();
    }
}
