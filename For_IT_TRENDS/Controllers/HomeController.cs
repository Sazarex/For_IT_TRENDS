using For_IT_TRENDS.Domain;
using For_IT_TRENDS.Domain.Entities;
using For_IT_TRENDS.Models;
using For_IT_TRENDS.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace For_IT_TRENDS.Controllers
{
    public class HomeController:Controller
    {
        private AppDbContext db;//БД
        
        public HomeController(AppDbContext context)
        {
            db = context;
        }



        public async Task<IActionResult> Index()
        {
            //Передаем в представление моделью все города из таблицы
            return View(await db.Cities.ToListAsync()) ;
        }


        /* При нажатии на кнопку "Создать" перекидывается на это действие
        т.к. метод httpGet, то он перекинет на представление Create.cshtml
        */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        /* Из представления Create.cshtml при добавлении города передается поле Title
         * и т.к. в представлении модель назначена City, то в метод передастся объект City.
         * и добавляем город в таблицу и перенаправляемся в Index
         */
        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            db.Cities.Add(city);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> DeleteCity(int CityId)//параметр передается из представления через тэг-хелпер
        {
            if (CityId != 0)
            {
                //Ищем строку в таблице по Id
                City? city = await db.Cities.FirstOrDefaultAsync(c => c.Id == CityId);
                if (city != null)
                {
                    //Удаляем строку из таблицы
                    db.Cities.Remove(city);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? CityId)
        {
            if (CityId != null)
            {
                //Поиск в таблице строк с CityId
                City? city = await db.Cities.FirstOrDefaultAsync(c => c.Id == CityId);
                if (city != null)
                {
                    //Возвращаем найденную строку и возвращаем в представление моделью
                    return View(city);
                }
            }
            return NotFound();
        }


        //Через представление Edit.cshtml мы через тэг-хелперы отправляем поле title и id города в таблице
        [HttpPost]
        public async Task<IActionResult> Edit(City city)
        {
            //Обновляем строку в таблице
            db.Cities.Update(city);
            await db.SaveChangesAsync();

            //Перенаправляемся на главную
            return RedirectToAction("Index");
        }


    }
}
