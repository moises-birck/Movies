using ApplicationMovies.Service;
using ApplicationMovies.Service.Interface;
using InfraMovie.Repository;
using InfraMovies.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container.
builder.Services.AddControllers();

// Saiba mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MoviesContext>(options =>
    options.UseInMemoryDatabase(databaseName: "MyBaseInMemory"), ServiceLifetime.Scoped);

builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

builder.Services.AddScoped<IMoviesInitializerService, MoviesInitializerService>();

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.StartAsync();

using (var scope = app.Services.CreateScope())
{
    var moviesInitializer = scope.ServiceProvider.GetRequiredService<IMoviesInitializerService>();
    await moviesInitializer.InitializeMovies();
}

var waitHandle = new ManualResetEventSlim();
waitHandle.Wait();