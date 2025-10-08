using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_API_Note;
using Project_API_Note.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<JwtConfiguration>();

// Bind JwtSettings from configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.AddSingleton(jwtSettings); // Register as a singleton
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            };
            options.Events = new JwtBearerEvents
            {
                OnChallenge = async context =>
                {
                    // Suppress the default response
                    context.HandleResponse();

                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    // Only write the custom response if one hasn't been written already
                    if (!context.Response.HasStarted)
                    {
                        var result = System.Text.Json.JsonSerializer.Serialize(new
                        {
                            status = 401,
                            message = "Unauthorized: Invalid or missing token"
                        });
                        await context.Response.WriteAsync(result);
                    }
                },
                OnAuthenticationFailed = context =>
                {
                    Console.WriteLine("🔴 Authentication failed: " + context.Exception.Message);
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    var result = System.Text.Json.JsonSerializer.Serialize(new
                    {
                        status = 401,
                        message = "Invalid or expired token"
                    });
                    return context.Response.WriteAsync(result);
                },
                OnForbidden = context =>
                {
                    Console.WriteLine("⛔ Forbidden: User has no access");
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";
                    var result = System.Text.Json.JsonSerializer.Serialize(new
                    {
                        status = 403,
                        message = "Forbidden: You do not have permission"
                    });
                    return context.Response.WriteAsync(result);
                }

            };




        });
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddAuthorization();


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

// ✅ Enable auth middleware
app.UseAuthentication();
app.Use(async (context, next) =>
{
    context.Response.Headers["Referrer-Policy"] = "no-referrer";
    await next();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
//builder.Services.AddJwtAuthentication(builder.Configuration);
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.Run();
