using Eclipseworks.TaskManagement.Automapper;
using Eclipseworks.TaskManagement.Core.Application.Ioc;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Configuration;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Context Connection
builder.Services.AddSingleton<DapperContext>();

// Services
builder.Services.AddPersistenceRepositories();
builder.Services.AddApplicationServices();

builder.Services.AddAutoMapper(typeof(TaskManagementProfile).Assembly);

// Add services to the container.

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
