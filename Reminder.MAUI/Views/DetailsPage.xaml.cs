using Reminder.MAUI.ViewModels;

namespace Reminder.MAUI.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}