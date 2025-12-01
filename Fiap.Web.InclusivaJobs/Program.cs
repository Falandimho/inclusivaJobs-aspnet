using Fiap.Web.InclusivaJobs.Data;
using Fiap.Web.InclusivaJobs.Data.Repository;
using Fiap.Web.InclusivaJobs.Mapping;
using Fiap.Web.InclusivaJobs.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework com Oracle
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Services e Repository
builder.Services.AddScoped<IVagaRepository, VagaRepository>();
builder.Services.AddScoped<IVagaService, VagaService>();

builder.Services.AddAutoMapper(typeof(Program));

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