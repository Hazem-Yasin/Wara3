namespace Wara3__web_api.Models
{
    public class Notifcation
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsSent { get; set; }

        #region ForgeinKey UserID
        public int UserId { get; set; }
        #endregion

        #region Navigation Property User
        public User User { get; set; }
        #endregion
    }
}
