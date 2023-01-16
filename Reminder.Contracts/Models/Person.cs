using Prism.Mvvm;
using SQLite;

namespace Reminder.Contracts.Models
{
    public class Person : BindableBase
    {
        private string? base64;
        private DateTime birthday = new DateTime(2000, 1, 10);
        private int id;
        private string? name;
        private string? middleName;
        private string? lastName;
        private string? position;

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => SetProperty(ref id, value); }
        public string? Name { get => name; set => SetProperty(ref name, value); }
        public string? MiddleName { get => middleName; set => SetProperty(ref middleName, value); }
        public string? LastName { get => lastName; set => SetProperty(ref lastName, value); }
        public string? Position { get => position; set => SetProperty(ref position, value); }
        public DateTime Birthday { get => birthday; set => SetProperty(ref birthday, value); }
        public string? Base64 { get => base64; set => SetProperty(ref base64, value); }
    }
}
