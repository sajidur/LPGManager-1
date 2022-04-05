using System.ComponentModel.DataAnnotations;

namespace LPGManager.Dtos
{
    public class CustomerDto:BaseDtos
    {
        public string? Image { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Image")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Name")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid Phone")]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide valid  Type //1 for retailer, 2 for customer")]
        public int CustomerType { get; set; } //1 for retailer, 2 for customer
    }
}
