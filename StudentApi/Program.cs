using Microsoft.EntityFrameworkCore;
using StudentBusiness.Services;
using StudentCore.Interfaces;
using StudentDataAccess;
using StudentDataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddDbContext<AppDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IExternalStudentService, ExternalStudentManager>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentManager>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();