using Microsoft.EntityFrameworkCore;
using VegBasket.Api.Data;
using VegBasket.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("VegBasket");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

AutoMigrateDb(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProductEndpoints();

app.Run();

static void AutoMigrateDb(IServiceProvider sp)
{
    var scope = sp.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    if (dataContext.Database.GetPendingMigrations().Any())
    {
        // We have some pending migration
        // Run the migration againts the database
        dataContext.Database.Migrate();
    }
}
