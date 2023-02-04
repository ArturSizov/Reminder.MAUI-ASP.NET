using MauiPopup.Views;
using Reminder.ViewModels.PopupViewModels;

namespace Reminder.Views.ViewsPopup;

public partial class PopupMessage : BasePopupPage
{
	public PopupMessage(PopupMessageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}