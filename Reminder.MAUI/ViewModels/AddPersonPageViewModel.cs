using Prism.Commands;
using Prism.Mvvm;
using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;
using Reminder.MAUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reminder.MAUI.ViewModels
{
    public class AddPersonPageViewModel : BindableBase
    {
        #region Private ptoperty
        private bool isEnabled;
        private IPersonData data;
        private ObservableCollection<Person> persons = new();
        #endregion

        #region Public property
        public Person Person { get; set; }
        public string Title => "Добавить";

        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
        public ObservableCollection<Person> Persons { get => persons; set => SetProperty(ref persons, value); }
        #endregion

        public AddPersonPageViewModel(IPersonData data)
        {
            this.data = data;

            Person = new Person();

            IsEnabled = true;
        }

        #region Commands
        public ICommand BackCommand => new DelegateCommand(async () =>
        {
            await Shell.Current.Navigation.PopToRootAsync();
        });

        public ICommand IsEnabledCommand => new DelegateCommand(() =>
        {
            IsEnabled = true;
        });

        public ICommand SaveCommand => new DelegateCommand(async() =>
        {
            await data.InsertPerson(Person);
            await Shell.Current.Navigation.PopToRootAsync();
        });

        public ICommand AddImageCommand => new DelegateCommand(async() =>
        {
            var customFileType = new FilePickerFileType(
               new Dictionary<DevicePlatform, IEnumerable<string>>
               {
                    { DevicePlatform.Android, new[] { "application/image" } },
                    { DevicePlatform.WinUI, new[] { ".jpg", ".png" } }
               });

            PickOptions options = new()
            {
                PickerTitle = "Выберите файл фотографии",
                FileTypes = customFileType,
            };

            var result = await FilePicker.Default.PickAsync(options);

            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }
            if (result != null)
            {
                var p = new MemoryStream(Convert.FromBase64String(result.FullPath));
            }
        });
        #endregion
    }
}
