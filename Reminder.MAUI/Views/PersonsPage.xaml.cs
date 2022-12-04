using Reminder.MAUI.ViewModels;

namespace Reminder.MAUI.Views;

public partial class PersonsPage : ContentPage
{
	public PersonsPage(PersonsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}