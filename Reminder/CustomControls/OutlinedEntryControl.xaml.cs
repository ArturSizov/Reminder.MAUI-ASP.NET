namespace Reminder.CustomControls;

public partial class OutlinedEntryControl : Grid
{
    public OutlinedEntryControl()
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
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(OutlinedEntryControl), defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: TextPropertyPropertyChanget);


    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create( nameof(Placeholder), typeof(string), typeof(OutlinedEntryControl));


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
        ChangesPlaceholder(Text);
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        TxtEntry.Focus();
    }

    #endregion

    #region Methods
    private static void TextPropertyPropertyChanget(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (OutlinedEntryControl)bindable;
        control.TxtEntry.Text = newValue as string;
    }
    private void ChangesPlaceholder(string text)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            lblPlaceholder.FontSize = 11;
            lblPlaceholder.TranslateTo(0, -20, 80, easing: Easing.Linear);
            lblPlaceholder.HorizontalTextAlignment = TextAlignment.Start;
        }
        else
        {
            lblPlaceholder.FontSize = 15;
#if ANDROID
            lblPlaceholder.TranslateTo(0, 5, 80, easing: Easing.Linear);
#elif WINDOWS
            lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.Linear);
#endif
            lblPlaceholder.HorizontalTextAlignment = TextAlignment.Center;
        }
    }
#endregion
}