using Reminder.Contracts.Models;

namespace Reminder.MAUI.Services
{
    public static class Helper
    {
        /// <summary>
        /// Add image method
        /// </summary>
        /// <param name="person"></param>
        public async static Task<FileResult> AddImage(Person person)
        {
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { "/image/jpeg" } },
                    { DevicePlatform.WinUI, new[] { ".jpg", ".png" } }
                });

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
                    var stream = await result.OpenReadAsync();

                    var image = File.ReadAllBytes(result.FullPath);

                    person.Base64 = Convert.ToBase64String(image);

                }

                return result;
            }
            catch (Exception) { }

            return null;
        }
    }
}
