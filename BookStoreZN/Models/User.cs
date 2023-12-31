﻿namespace BookStoreZN.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
