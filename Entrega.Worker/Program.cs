using Entrega.Worker.Middleware;
using EntregaWorker.Application;
using EntregaWorker.Infraestructure;
using Entrega.Worker.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Capa de aplicacion
builder.Services.AddApplication();

//Capa de infra
var connectionString = builder.Configuration.GetConnectionString("dbEntregas-cnx");
builder.Services.AddInfraestructure(connectionString);
// Adicionando el background service
builder.Services.AddHostedService<RegistrarEntregaWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Adicionar middleware customizado para tratar las excepciones
app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
