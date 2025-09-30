namespace Project_API_Note.DataModel
{
    public class UserLoginDataModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateNow { get; set; }
    }
}
