using ApplicationCore;
using Infrastructure;
using Web;
using Web.Helpers;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("DefaultConnection")!;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext(connStr);
builder.Services.AddIdentity();
builder.Services.AddRepositories();
builder.Services.AddJWT(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// auto mapper configuration for Business logic
builder.Services.AddAutoMapper();

// add custom servies from Business logic
builder.Services.AddCustomServices();

var app = builder.Build();

// Use CORS
app.UseCors(builder => builder.AllowAnyOrigin());

using (var scope = app.Services.CreateScope())
{
	scope.ServiceProvider.SeedRoles().Wait();
	scope.ServiceProvider.SeedAdmin().Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
