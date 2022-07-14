using For_IT_TRENDS.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();




string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//Парс строки подключ
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)); //Добавление дб-контекста в сервисы

//Подключаем сервис аутиентификации через куки
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Login");
    });

var app = builder.Build();
//Добавление middleware авторизации и аутентификации
app.MapDefaultControllerRoute();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
