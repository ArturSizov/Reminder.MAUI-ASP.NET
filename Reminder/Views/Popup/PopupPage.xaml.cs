namespace Reminder.Views.Popup;
using CommunityToolkit.Maui.Views;
using Reminder.ViewModels.Popup;

public partial class PopupPage : Popup
{
	public PopupPage(PopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}