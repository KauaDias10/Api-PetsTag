using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PetApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura a conexão com o banco de dados MySQL
builder.Services.AddDbContext<PetContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 38))));

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pet API", Version = "v1" });
});

// Configura o pipeline de solicitação
var app = builder.Build();

// Configura a porta
app.Urls.Add("http://0.0.0.0:5001"); // Ou a porta desejada

// Habilita o Swagger se estiver em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet API V1");
        c.RoutePrefix = string.Empty; // Swagger como página principal
    });
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
