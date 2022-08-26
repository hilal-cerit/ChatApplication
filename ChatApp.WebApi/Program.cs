using Business.Concrete;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ChatAppContext>();
        builder.Services.AddScoped<DalUser>();
        builder.Services.AddScoped<UserManager>();

        builder.Services.AddScoped<ChatAppContext>();
        builder.Services.AddScoped<DalMessage>();
        builder.Services.AddScoped<MessageManager>();

        builder.Services.AddAutoMapper(typeof(Program).Assembly);




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
}