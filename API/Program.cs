
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContex>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy
.AllowAnyHeader()
.AllowAnyHeader()
.WithOrigins("http://localhost:4200")
);

app.MapControllers();

using (var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    try{
        var contex = services.GetRequiredService<DataContex>();
        contex.Database.Migrate();
        Seed.SeedBata(contex);
    }

    catch(System.Exception e)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error occured while seeding the database");
    }
}
//app.UseHttpsRedirection();
app.MapControllers();
app.Run();