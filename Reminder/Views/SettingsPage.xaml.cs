using Reminder.ViewModels;

namespace Reminder.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}