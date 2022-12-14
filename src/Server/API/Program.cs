using ProMag.Server.Api.Configurations;
using ProMag.Server.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHealthChecks();

builder.Services.AddConnectionProvider(builder.Configuration);
builder.Services.AddAppSettings(builder.Configuration);

builder.Services.AddCorsMechanism();
builder.Services.AddServerLogging();
builder.Services.AddCaching();
builder.Services.AddNewtonsoft();
builder.Services.AddAutoMapper();

builder.Services.ConfigureIdentity();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureSupervisor();

builder.Services.AddServices();

// Configure app
var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 docs"));

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseMiddleware<JwtMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

public partial class Program
{
}