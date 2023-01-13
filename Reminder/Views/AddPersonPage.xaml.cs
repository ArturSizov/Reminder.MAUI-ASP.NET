using Reminder.ViewModels;

namespace Reminder.Views;

public partial class AddPersonPage : ContentPage
{
	public AddPersonPage(AddPersonPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}