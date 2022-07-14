using For_IT_TRENDS.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();




string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//���� ������ �������
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)); //���������� ��-��������� � �������

//���������� ������ ��������������� ����� ����
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Login");
    });

var app = builder.Build();
//���������� middleware ����������� � ��������������
app.MapDefaultControllerRoute();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
