﻿namespace For_IT_TRENDS.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
