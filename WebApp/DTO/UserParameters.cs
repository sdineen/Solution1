﻿namespace WebApp.DTO
{
    //encapsulates HTTP request parameters
    public class UserParameters
    {
        public string? ProductId { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public override string ToString() => 
            string.Format($"{Username} {Name} {Token}");
    }
}
