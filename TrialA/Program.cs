using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrialA.DATA;
using TrialA.REPOS.Implemntion;
using TrialA.REPOS.interfacess;
using AutoMapper;


namespace TrialA
{
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
           
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
            builder.Services.AddScoped<IJobRepo, JobRepo>();
            builder.Services.AddScoped<ICompnyRepo, CompnyRepo>();
            builder.Services.AddScoped<IApplication, AplicationRepo>();
            builder.Services.AddDbContext<Appdbcontext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("hh")));


           

           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
