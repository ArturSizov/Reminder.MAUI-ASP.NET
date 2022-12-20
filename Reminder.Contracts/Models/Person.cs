using Prism.Mvvm;
using SQLite;

namespace Reminder.Contracts.Models
{
    public class Person : BindableBase
    {
        private string? base64;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public DateTime Birthday { get; set; } = new DateTime(2000, 1, 10);
        public int Age { get; set; }
        public int Days { get; set; }
        public string? Base64 { get => base64; set => SetProperty(ref base64, value); }
    }
}
