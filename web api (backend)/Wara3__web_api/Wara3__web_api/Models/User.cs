namespace Wara3__web_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool AllowNotifcations { get; set; }

        public ICollection<Addiction>? Addictions { get; set; }
    }
}
