using For_IT_TRENDS.Domain;
using For_IT_TRENDS.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

builder.Services.AddAuthorization();
//Add the JWT authentication and introduce options from AuthOptions class
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true


        };
    });


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//Парс строки подключ
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)); //Добавление дб-контекста в сервисы


var app = builder.Build();
//Adding Authorization/Authentication middlewares at the project
app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();


app.Run();
