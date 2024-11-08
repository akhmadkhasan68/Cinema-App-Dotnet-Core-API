using CinemaApp;
using CinemaApp.Infrastructures.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add Services to The Container
var appServiceProvider = new AppServiceProvider(builder);
appServiceProvider.InitServiceProvider();
appServiceProvider.RegisterServices();
appServiceProvider.RegisterRepository();
appServiceProvider.RegisterExceptionHandler();

var app = builder.Build();

// Exception Handling
app.UseExceptionHandler();


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
