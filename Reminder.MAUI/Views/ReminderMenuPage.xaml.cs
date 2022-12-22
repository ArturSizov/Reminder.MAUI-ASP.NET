using Reminder.MAUI.ViewModels;

namespace Reminder.MAUI.Views;

public partial class ReminderMenuPage : ContentPage
{
	public ReminderMenuPage(RemindreMenuPageViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}