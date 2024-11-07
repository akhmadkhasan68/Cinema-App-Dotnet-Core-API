using CinemaApp;
using CinemaApp.Infrastructures.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add Services to The Container
new AppServiceProvider(builder).ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseMiddleware<LoggingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
