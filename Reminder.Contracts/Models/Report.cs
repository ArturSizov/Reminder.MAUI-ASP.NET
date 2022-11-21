namespace Reminder.Contracts.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
        public string? Base64 { get; set; }

    }
}
