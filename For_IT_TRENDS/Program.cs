using For_IT_TRENDS.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();




string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//���� ������ �������
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)); //���������� ��-��������� � �������


var app = builder.Build();

app.MapDefaultControllerRoute();


app.Run();
