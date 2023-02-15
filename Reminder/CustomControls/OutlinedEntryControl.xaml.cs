namespace Reminder.CustomControls;

public partial class OutlinedEntryControl : Grid
{
    public OutlinedEntryControl()
    {
        InitializeComponent();
    }


    #region Public property
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set { SetValue(TextProperty, value); }
    }

    public new bool IsEnabled
    {
        get => (bool)GetValue(IsEnabledProperty);
        set { SetValue(IsEnabledProperty, value); }
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }

    #endregion

    #region BindableProperty

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(OutlinedEntryControl),
        propertyChanged: TextPropertyPropertyChanget);

    private static void TextPropertyPropertyChanget(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (OutlinedEntryControl)bindable;
        var t = control.TxtEntry.Text = newValue as string;

        if(!string.IsNullOrWhiteSpace(t))
        {
            
        }
    }


    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create( nameof(Placeholder), typeof(string), typeof(OutlinedEntryControl),
        propertyChanged: PlaceholderPropertyPropertyChanget);

    private static void PlaceholderPropertyPropertyChanget(BindableObject bindable, object oldValue, object newValue)
    {
        
    }

    public static readonly new BindableProperty IsEnabledProperty = BindableProperty.Create( nameof(IsEnabled), typeof(bool), typeof(OutlinedEntryControl), true, BindingMode.TwoWay);

    #endregion

    #region Events
    private void TxtEntry_Focused(object sender, FocusEventArgs e)
    {
        lblPlaceholder.FontSize = 11;
        lblPlaceholder.TranslateTo(0, -20, 80, easing: Easing.Linear);
        lblPlaceholder.HorizontalTextAlignment = TextAlignment.Start;
    }

    private void TxtEntry_Unfocused(object sender, FocusEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            lblPlaceholder.FontSize = 11;
            lblPlaceholder.TranslateTo(0, -20, 80, easing: Easing.Linear);
            lblPlaceholder.HorizontalTextAlignment = TextAlignment.Start;
        }
        else
        {
            lblPlaceholder.FontSize = 15;
            lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.Linear);
            lblPlaceholder.HorizontalTextAlignment = TextAlignment.Center;
            lblPlaceholder.HorizontalOptions = LayoutOptions.Center;
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        TxtEntry.Focus();
    }

    #endregion
}