﻿using For_IT_TRENDS.Domain;
using For_IT_TRENDS.Domain.Entities;
using For_IT_TRENDS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        public IActionResult Login(User loginUser)
        {
            if (loginUser!= null)
            {
                //Находим в таблице пользователей пользователя с таким же логином и паролем
                User? user = db.Users.FirstOrDefault(u => u.Login == loginUser.Login &&
                (PasswordService.IsPasswordsEquals(loginUser.Password, u.Password)));

                if (user != null)
                {
                    //Добавляем клайм с логином
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, loginUser.Login) };

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
                        username = user.Login
                    };

                    
                    Request.Headers.Add("Authorization", "Bearer " + jwt);
                    return Ok(responce);

                }
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
