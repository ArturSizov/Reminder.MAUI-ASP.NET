using Reminder.Contracts.Models;
using Reminder.ViewModels.PopupViewModels;
using Reminder.Views.ViewsPopup;

namespace Reminder.Services
{
    public static class Helper
    {
        /// <summary>
        /// Add image method
        /// </summary>
        public async static Task<string> AddImage()
        {
            string str = null;
            PickOptions options = new()
            {
                PickerTitle = "Выберите файл фотографии",
                FileTypes = FilePickerFileType.Images
            };
            try
            {
                var result = await FilePicker.Default.PickAsync(options);

                if (result != null)
                {
                    var image = File.ReadAllBytes(result.FullPath);

                    str = Convert.ToBase64String(image);
                }

                return str;
            }
            catch (Exception) { }

            return null;
        }

        /// <summary>
        /// Returns days before birthday
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int GetDaysAge(DateTime birthday)
        {
            var today = DateTime.Today;

            var date = birthday.AddYears(today.Year - birthday.Year);

            if (date < today)
                date = date.AddYears(1);

            var days = (date - today).Days;

            if (days == 0)
            {
                return (date.AddYears(1) - today).Days;
            }
            else return days;
        }

        /// <summary>
        /// Ihformational message
        /// </summary>
        /// <param name="person"></param>
        /// <param name="time"></param>
        public async static Task Announcement(Person person, int time)
        {
            if (person.Birthday.Month == DateTime.Now.Month & person.Birthday.Day == DateTime.Now.Day & time <= (DateTime.Now.TimeOfDay).Hours)
            {
#if ANDROID
                await MauiPopup.PopupAction.DisplayPopup(new PopupMessage(new PopupMessageViewModel($"Напоминание для {person.Name} {person.LastName} сработает через {Helper.GetDaysAge(person.Birthday)} дней(я), " +
                    $"в {time} ч.")));
#elif WINDOWS
                await Shell.Current.DisplayAlert("Информация",$"Напоминание для {person.Name} {person.LastName} сработает через {Helper.GetDaysAge(person.Birthday)} дней(я), " +
                    $"в {time} ч.", "Ok");
#endif
            }

            else if (person.Birthday.Month == DateTime.Now.Month & person.Birthday.Day == DateTime.Now.Day & time > (DateTime.Now.TimeOfDay).Hours)
            {
#if ANDROID
                await MauiPopup.PopupAction.DisplayPopup(new PopupMessage(new PopupMessageViewModel($"Напоминание для {person.Name} {person.LastName} сработает сегодня, в {time} ч.")));
#elif WINDOWS
                await Shell.Current.DisplayAlert("Информация", $"Напоминание для {person.Name} {person.LastName} сработает сработает сегодня, в {time} ч.", "Ok");
#endif
            }
            else
            {
#if ANDROID
                await MauiPopup.PopupAction.DisplayPopup(new PopupMessage(new PopupMessageViewModel($"Напоминание для {person.Name} {person.LastName} сработает через {Helper.GetDaysAge(person.Birthday)} дней(я), " +
                   $"в {time} ч.")));
#elif WINDOWS
                await Shell.Current.DisplayAlert("Информация", $"Напоминание для {person.Name} {person.LastName} сработает через {Helper.GetDaysAge(person.Birthday)} дней(я), в {time} ч.", "Ok");

#endif
            }
        }
    }
}
