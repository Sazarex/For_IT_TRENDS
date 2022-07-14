using For_IT_TRENDS.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();




string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//Парс строки подключ
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)); //Добавление дб-контекста в сервисы


var app = builder.Build();

app.MapDefaultControllerRoute();


app.Run();
