using Reminder.Contracts.Models;
using Reminder.Interfaces;
using Reminder.ViewModels;
using System.Collections.ObjectModel;

namespace Reminder.Views;

public partial class PersonsPage : ContentPage
{
    public PersonsPage(PersonsPageViewModel vm)
	{
        InitializeComponent(); 
        BindingContext = vm;
    }
}