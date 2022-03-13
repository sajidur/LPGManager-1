namespace LPGManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
