﻿namespace LPGManager.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }        
        public string SupplierName { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int? Phone { get; set; }
        public string? Companytype { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
