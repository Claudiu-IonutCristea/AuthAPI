global using ErrorOr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//My services


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseExceptionHandler("/error");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
