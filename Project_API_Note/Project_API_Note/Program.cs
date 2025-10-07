using Microsoft.EntityFrameworkCore;
using Project_API_Note;
using Project_API_Note.Jwt;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<JwtConfiguration>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//service to connect with connection string that we store in appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//builder.Services.AddJwtAuthentication(builder.Configuration);
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
