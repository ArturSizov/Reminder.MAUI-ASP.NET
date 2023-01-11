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
    }
}
