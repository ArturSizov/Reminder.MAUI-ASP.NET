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
        private readonly ISettingsService settings;
        private ObservableCollection<Person> persons = new();
        private bool isBusy;
        private bool isVisibleEntry;
        private bool isVisibleTitle;
        private string textSearch;
        private  ObservableCollection<Person> serPersons = new(); //Immutable collection to search

        #endregion

        #region Public property
        public string Title => "Напоминалка";
        public ObservableCollection<Person> Persons
        {
            get => persons;
            set
            {
#if ANDROID
            ClearingСache();
#endif
                SetProperty(ref persons, value);
            }
        }
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); } //ActivityIndicator is busy
        public bool IsVisibleEntry { get => isVisibleEntry; set => SetProperty(ref isVisibleEntry, value); } //ActivityIndicator is Entry 
        public bool IsVisibleTitle { get => isVisibleTitle; set => SetProperty(ref isVisibleTitle, value); }
        public string TextSearch
        {
            get => textSearch;
            set
            {
                SetProperty(ref textSearch, value);

                if (textSearch?.Length > 0)
                {
                    Search();
                }
                else
                {
                    GetPersons();
                }

            }
        }
        #endregion
        public PersonsPageViewModel(IRepository data, IReminderNotificationServices notification, ISettingsService settings)
        {
            this.data = data;
            this.notification = notification;
            this.settings = settings;
            IsVisibleTitle = true;
            IsVisibleEntry = false;
            GetPersons();
        }

        #region Methods
        private void Search()
        {
            var p = serPersons.Where(p => p.Name != null && p.Name.Contains(TextSearch, StringComparison.OrdinalIgnoreCase)
                    || p.LastName != null && p.LastName.Contains(TextSearch, StringComparison.OrdinalIgnoreCase)
                    || p.MiddleName != null && p.MiddleName.Contains(TextSearch, StringComparison.OrdinalIgnoreCase)).ToList();
            if (p.Count > 0)
            {
                Persons.Clear();

                foreach (var item in p)
                {
                    Persons.Add(item);
                }
            }
            else Persons.Clear();
        }
        /// <summary>
        /// Get Persons method
        /// </summary>
        private async void GetPersons()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                data.Persons = new ObservableCollection<Person>(await data.GetPersons());

                Persons.Clear();
                foreach (var item in data.Persons)
                {
                    Persons.Add(item);
                    await notification.AddNotification(item, settings.Time);
                }
                serPersons = new ObservableCollection<Person>(Persons);
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
        public ICommand GoToAddPersonCommand => new DelegateCommand(async() =>
        {
            await Shell.Current.GoToAsync(nameof(AddPersonPage));
        });

        /// <summary>
        /// Go to report command
        /// </summary>
        public ICommand GoToReportsCommand => new DelegateCommand(async() =>
        {
            await Shell.Current.GoToAsync("...");
        });

        public ICommand IsEnabledEntryCommand => new DelegateCommand(() =>
        {
            if(IsVisibleEntry) IsVisibleEntry = false;
            else IsVisibleEntry = true;

            if (IsVisibleTitle == false)
            {
                IsVisibleTitle = true;
                TextSearch = null;
            }
            else IsVisibleTitle = false;
        });

        #endregion
    }
}
