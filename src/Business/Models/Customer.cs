namespace Business.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}