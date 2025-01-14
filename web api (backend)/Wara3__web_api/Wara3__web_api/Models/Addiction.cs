namespace Wara3__web_api.Models
{

    public class Addiction
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the addiction (e.g., "Smoking", "Caffeine")
        public string Description { get; set; } // Brief description of the addiction
        public DateTime StartDate { get; set; } // When the user started tracking this addiction
        public DateTime? LastRelapseDate { get; set; } // The last time the user relapsed
        public int DaysClean => (LastRelapseDate.HasValue ? (DateTime.Now - LastRelapseDate.Value).Days : (DateTime.Now - StartDate).Days); // Days since last use or start date

        // Foreign Key
        public int UserId { get; set; } // Links the addiction to a user

        // Navigation Property
        public User User { get; set; } // Associated user
    }

}