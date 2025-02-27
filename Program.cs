using Microsoft.EntityFrameworkCore;
using ZooAPI.Repository;
using ZooAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ZooAPI.Context.ApplicationContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<AnimalService>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
