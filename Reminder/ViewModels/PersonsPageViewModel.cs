using Plugin.LocalNotification;
using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Plugin.LocalNotification.AndroidOption;

namespace Reminder.ViewModels
{
    public class PersonsPageViewModel : BindableBase
    {
        #region Private property
        private readonly IRepository data;
        private ObservableCollection<Person> persons;
        private bool isBusy;

        #endregion
        #region Public property
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); } //ActivityIndicator is busy

        #endregion
        public PersonsPageViewModel(IRepository data)
        {
            this.data = data;
            GetPersons();

        #if ANDROID
            Notification();

        #endif
        }
        #region Methods

        /// <summary>
        /// Get Persons method
        /// </summary>
        private async void GetPersons()
        {
            if(IsBusy) return;

            try
            {
                IsBusy = true;
                Persons = data.Persons = new ObservableCollection<Person>(await data.GetPersons());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void Notification()
        {
            var request = new NotificationRequest
            {
                NotificationId = 1337,
                Title = Title,
                Description = $"Поздравить: {data.Persons.Count}",
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                    RepeatType = NotificationRepeat.TimeInterval,
                    NotifyRepeatInterval = TimeSpan.FromSeconds(25)
                },
                Android = new AndroidOptions
                {
                    IconSmallName =
                    {
                          ResourceName = "notification"
                    }
                }
        };
           
            LocalNotificationCenter.Current.Show(request);
        }

        #endregion
        #region Command

        /// <summary>
        /// Go to details command
        /// </summary>
        public ICommand GoToDetailsPersonCommand => new DelegateCommand<Person>(async(person) =>
        {
            await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>
            {
                {nameof(DetailsPage),
                    new Person
                    {
                         Name = person.Name, Id = person.Id, Base64 = person.Base64,
                         Birthday= person.Birthday, LastName = person.LastName, MiddleName = person.MiddleName, Position = person.Position
                    }
                }});
        });

        /// <summary>
        /// Go to add person command
        /// </summary>
        public ICommand GoToAddPersonCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.GoToAsync(nameof(AddPersonPage));
        });

        /// <summary>
        /// Go to report command
        /// </summary>
        public ICommand GoToReportsCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.GoToAsync("...");
        });

        private static string GetDatabasePath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }

        #endregion
    }
}
