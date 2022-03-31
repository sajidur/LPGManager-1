using System.ComponentModel.DataAnnotations;

namespace LPGManager.Dtos
{
    public class CompanyDtos:BaseDtos
    {
        public long Id { get; set; }
        public string? Image { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please provide valid Name")]
        public string CompanyName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Address")]
        public string? Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Phone No")]
        public string Phone { get; set; }
        public int CompanyType { get; set; }
    }
}
