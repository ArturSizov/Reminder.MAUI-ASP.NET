using Reminder.ViewModels;

namespace Reminder.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsPageViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}