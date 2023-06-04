using API.Data;
using Microsoft.EntityFrameworkCore;

// starting file!!

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// dependency injection container
// ordering doesnt matter

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Inside the HTTP request pipeline 
// as a request comes into our API is handled by our API 
// and then in response is sent out of our API.
// What's going on between the request being received by API
//  and the response being sent out is what's
// referred to as the HTTP request pipeline.
// ORDERING IS IMPORTANT


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
});

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "A problem has ocurred during migration.");
}

app.Run();
