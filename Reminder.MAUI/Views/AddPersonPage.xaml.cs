using Reminder.MAUI.ViewModels;

namespace Reminder.MAUI.Views;

public partial class AddPersonPage : ContentPage
{
	public AddPersonPage(AddPersonPageViewModel vm)
	{
		InitializeComponent();
		
		BindingContext = vm;
	}
}