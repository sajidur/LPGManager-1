using System.ComponentModel.DataAnnotations;

namespace LPGManager.Dtos
{
    public class SupplierDtos
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Name")]
        public string Name { get; set; }
        public string? Image { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Address")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Phone")]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid CompanyType")]
        public int Companytype { get; set; }
    }
}
