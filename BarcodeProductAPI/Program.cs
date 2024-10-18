using BarcodeProductAPI.Data;
using BarcodeProductAPI.Services;
using Microsoft.OpenApi.Models;
using YourProject.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<MongoDbContext>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Barcode Product API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Barcode Product API V1");
    c.RoutePrefix = string.Empty; // Swagger UI'yi ana dizine koyar
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
