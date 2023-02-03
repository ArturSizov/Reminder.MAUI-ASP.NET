using CommunityToolkit.Maui.Views;
using Reminder.ViewModels.PopupViewModels;

namespace Reminder.Views.ViewsPopup;

public partial class PopupMessage : Popup
{
	public PopupMessage(PopupMessageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}