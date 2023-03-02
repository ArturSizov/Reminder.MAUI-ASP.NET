using Prism.Commands;
using System.Windows.Input;

namespace Reminder.CustomControls;

public partial class SearchEntryControls : Grid
{
    public SearchEntryControls()
    {
        InitializeComponent();
        ChangesPlaceholder(null);
    }


    #region Public property
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set
        {
            SetValue(TextProperty, value);
            ChangesPlaceholder(Text);
        }
    }

    public new bool IsVisible
    {
        get => (bool)GetValue(IsVisibleProperty);
        set { SetValue(IsVisibleProperty, value); }
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }
    #endregion

    #region BindableProperty
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(SearchEntryControls), defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: TextPropertyPropertyChanget);


    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(SearchEntryControls));

    public static readonly new BindableProperty IsVisibleProperty = BindableProperty.Create(nameof(IsVisible), typeof(bool), typeof(SearchEntryControls), true, BindingMode.TwoWay,
       propertyChanged: IsVisiblePropertyChanget);
    #endregion

    #region Events
    private void TxtEntry_Focused(object sender, FocusEventArgs e)
    {
        lblPlaceholder.IsVisible = false;
    }

    private void TxtEntry_Unfocused(object sender, FocusEventArgs e)
    {
        ChangesPlaceholder(Text);
        lblPlaceholder.IsVisible = true;
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        TxtEntry.Focus();
    }

    #endregion

    #region Methods
    private static void TextPropertyPropertyChanget(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (SearchEntryControls)bindable;
        control.TxtEntry.Text = newValue as string;
    }
    private static void IsVisiblePropertyChanget(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (SearchEntryControls)bindable;

        if ((bool)newValue)
        {
            control.searchBorder.IsVisible = true;
            control.lblPlaceholder.IsVisible = true;
        }
        else
        {
            control.searchBorder.IsVisible = false;
            control.lblPlaceholder.IsVisible = false;
        }
    }
    private void ChangesPlaceholder(string text)
    {
        TxtEntry.IsEnabled = true;

        if (string.IsNullOrEmpty(Text))
            lblPlaceholder.IsVisible = true;
        else lblPlaceholder.IsVisible = false;
    }
    #endregion
    #region Commands
    public ICommand ReturnCommand => new DelegateCommand(() =>
    {
        TxtEntry.IsEnabled = false;
    });
    #endregion
}