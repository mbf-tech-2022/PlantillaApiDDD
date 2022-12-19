
using Microsoft.EntityFrameworkCore;

using MiEjemploDDD.Application;
using MiEjemploDDD.Infrastructure;
using MiEjemploDDD.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var MyAllow = "CorsPolicy";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(op =>
{
    op.AddPolicy(MyAllow, builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddDbContext<MiEjemploDDDDbContext>(opts => opts.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["ConnectionString"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllow);
app.MapControllers();

app.Run();
