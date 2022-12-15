using Reminder.Contracts.Models;

namespace Reminder.MAUI.Services
{
    public static class Helper
    {
        /// <summary>
        /// Add image method
        /// </summary>
        /// <param name="person"></param>
        public async static void AddImage(Person person)
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
                    var image = File.ReadAllBytes(result.FullPath);

                    person.Base64 = Convert.ToBase64String(image);
                }
            }
        }
    }
}
