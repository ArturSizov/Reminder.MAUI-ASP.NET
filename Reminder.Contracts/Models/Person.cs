namespace Reminder.Contracts.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public int Days { get; set; }
        public string? Base64 { get; set; }
    }
}
