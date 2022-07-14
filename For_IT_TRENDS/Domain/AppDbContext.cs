using For_IT_TRENDS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace For_IT_TRENDS.Domain
{
    public class AppDbContext: DbContext
    {
        #region DataSets
        public DbSet<City> Cities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Polyclinic> Polyclinics{ get; set; }
        public DbSet<Specialization> Specializations{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            Database.EnsureCreated();//Создается бд, если её нет
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            #region Comments
            ////Создается роль админа
            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Id = "175eb6e7-b77d-4f21-8ddf-7c0a3ff12faa",
            //    Name = "admin",
            //    NormalizedName = "ADMIN"
            //});

            ////Создается юзер админ
            //builder.Entity<IdentityUser>().HasData(new IdentityUser
            //{
            //    Id = "98148311-caa9-478a-9193-b570f8c270ea",
            //    UserName = "admin",
            //    NormalizedUserName = "ADMIN",
            //    Email = "my@email.com",
            //    NormalizedEmail = "MY@EMAIL.COM",
            //    EmailConfirmed = true,
            //    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "qazwsxedc"),
            //    SecurityStamp = String.Empty
            //});

            ////Сопоставление юзера с ролью
            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = "175eb6e7-b77d-4f21-8ddf-7c0a3ff12faa",
            //    UserId = "98148311-caa9-478a-9193-b570f8c270ea"
            //});
            #endregion

            #region Seeds
            //Сид в таблицы
            builder.Entity<City>().HasData(new City[]{ new City
            {
                Id = 1,
                Title = "Москва"
            },
            new City
            {
                Id = 2,
                Title = "Санкт-Петербург"
            }});



            Role adminRole = new Role()
            {
                RoleId = 1,
                Name = "Admin",

            };
            Role userRole = new Role()
            {
                RoleId=2,
                Name = "User",

            };

            User admin = new User()
            {
                Id=1,
                Login = "Admin",
                Password = "olUO6rBySmkRksoTmC5uvQ==",
                RoleId = adminRole.RoleId
            };

            User user = new User()
            {
                Id=2,
                Login = "User",
                Password = null,
                RoleId = userRole.RoleId
            };



            builder.Entity<User>().HasData(new User[] { admin, user });

            builder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            #endregion

            base.OnModelCreating(builder);
        }


    }
}
