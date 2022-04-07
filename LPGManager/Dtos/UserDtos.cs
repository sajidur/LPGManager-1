namespace LPGManager.Dtos
{
    public class UserDtos:BaseDtos
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int UserType { get; set; } //1=for retailer 2=consumer 3=dealer  4=company
        public string Password { get; set; }
        public List<RoleDtos> Roles { get; set; }
    }
}
