﻿namespace LPGManager.Models
{
    public class Company:BaseEntity
    {
        public string? Image { get; set; }
        public string CompanyName { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; }
        public int CompanyType { get; set; }
    }
}
