using Microsoft.OpenApi.Models;

// Can add Services to builder. e.g `builder.Services.AddCors(options => {});
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
   {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Description = "First app API", Version = "v1" });
   });

var app = builder.Build();


app.MapHealthChecks("/health");
app.UseSwagger();
app.UseSwaggerUI(c =>
   {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
   });

// App instance sets-up routing.
app.MapGet("/", () => "Hello World!");
app.MapGet("/health", () => "Hello World!");

app.Run();
