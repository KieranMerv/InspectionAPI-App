using InspectionAPI.Data;
using InspectionAPI.DbInitializer;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// var appHost = builder.Configuration["AppHost"];

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    var appHost = builder.Configuration["AppHost"];
    options.AddPolicy(name: myAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins(appHost)
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// builder.Services.AddCors();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

// app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(appHost));

SeedDataBase();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDataBase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}