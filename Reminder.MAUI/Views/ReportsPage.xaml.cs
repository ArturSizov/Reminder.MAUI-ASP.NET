using Reminder.MAUI.ViewModels;

namespace Reminder.MAUI.Views;

public partial class ReportsPage : ContentPage
{
	public ReportsPage(RerportsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}