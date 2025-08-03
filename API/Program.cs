using Application.Activities.Queries;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline. (Middleware) (Here the order matters)
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod()
.WithOrigins("http://localhost:3000", "https://localhost:3000"));

app.MapControllers();

//Service locator patterns
//Here we aceess the services that we declare in this specific class because we can't inject them right here.
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<AppDbContext>();
    //Instead of manual migration, this line does the migrations as soon as the API starts.
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An eerror occurred during migration.");
}

app.Run();
