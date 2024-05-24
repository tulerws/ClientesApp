using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Services;
using ClientesApp.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(config => { config.LowercaseUrls = true; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Inje��es de depend�ncia do projeto

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteDomainService, ClienteDomainService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();
app.Run();
