using Employee3Dep.Services;
using Microsoft.OpenApi.Models; // ✅ Add this
using Microsoft.AspNetCore.Builder;
using Employee3Dep.Middleware; // ✅ May be needed for UseSwaggerUI()

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IEmployee3Service, Employee3Service>();
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddControllers();

// ✅ Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee3 API",
        Version = "v1",
        Description = "API for managing employees and products"
    });
});

var app = builder.Build();

// ✅ Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee3 API v1");
        options.RoutePrefix = string.Empty; // optional: open Swagger UI at root URL
    });
}

app.UseMiddleware<LoginMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from .NET Core1");
});

app.Run();
