using For_IT_TRENDS.Domain;
using For_IT_TRENDS.Domain.Entities;
using For_IT_TRENDS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace For_IT_TRENDS.Controllers
{
    public class AuthController:Controller
    {
        private AppDbContext db;

        public AuthController(AppDbContext _db)
        {
            db = _db;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IResult Login(User loginUser)
        {
            if (loginUser != null)
            {
                byte[] source = ASCIIEncoding.ASCII.GetBytes(loginUser.Password);
                byte[] hashedPassword = new MD5CryptoServiceProvider().ComputeHash(source);

                string hashedPasswordString = Convert.ToBase64String(hashedPassword);


                //Находим в таблице пользователей пользователя с таким же логином и паролем
                User? user = db.Users.FirstOrDefault(u => u.Login == loginUser.Login &&
                (hashedPasswordString == u.Password));

                if (user != null)
                {
                    //Добавляем клайм с логином
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, loginUser.Login),
                    new Claim(ClaimTypes.Role, loginUser.Role.Name)};

                    //Создаем jwt токен
                    var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                    //Сериализуем jwt токен в формат JSON
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                    //Создаем ответ с jwt токеном
                    var responce = new
                    {
                        access_token = encodedJwt,
                        username = user.Login,
                        role = user.Role.Name
                    };


                    //Request.Headers.Add("Authorization", "Bearer " + jwt);
                    return Results.Json(responce);
                    //return Ok(responce);

                }
                    return Results.Unauthorized();

            }
            return Results.Unauthorized();
        }


        [Authorize]
        public string ForAdmin()
        {
            return "For Admin";
        }

    }


}
