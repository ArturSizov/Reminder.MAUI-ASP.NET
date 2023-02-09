using Plugin.LocalNotification;
using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Reminder.ViewModels
{
    public class PersonsPageViewModel : BindableBase
    {
        #region Private property
        private readonly IRepository data;
        private IReminderNotificationServices notification;
        private readonly INotificationService notificationService;
        private ObservableCollection<Person> persons;
        private bool isBusy;

        #endregion

        #region Public property
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); } //ActivityIndicator is busy

        #endregion
        public PersonsPageViewModel(IRepository data, IReminderNotificationServices notification, INotificationService notificationService)
        {
#if ANDROID
            ClearingСache();
#endif
            this.data = data;
            this.notification = notification;
            this.notificationService = notificationService;
            GetPersons();
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

                foreach (var item in Persons)
                {
                   await notification.AddNotification(item, 21);
                }
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

        //Cookie deletion method for Android
        private void ClearingСache()
        {
            var imageManagerDiskCache = Path.Combine(FileSystem.CacheDirectory, "image_manager_disk_cache");

            if (Directory.Exists(imageManagerDiskCache))
            {
                foreach (var imageCacheFile in Directory.EnumerateFiles(imageManagerDiskCache))
                {
                    File.Delete(imageCacheFile);
                }
            }
        }
        //Get database path
        private static string GetDatabasePath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);
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
        #endregion
    }
}
