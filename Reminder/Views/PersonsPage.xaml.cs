using Reminder.ViewModels;

namespace Reminder.Views;

public partial class PersonsPage : ContentPage
{
    public PersonsPage(PersonsPageViewModel vm)
	{
        InitializeComponent(); 
        BindingContext = vm;
    }
}