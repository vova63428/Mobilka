using System.Globalization;
using TenElement.Resources;

namespace TenElement;

public partial class MainPage : ContentPage
{
    private int _count = 0;

    public MainPage()
    {
        InitializeComponent();

        ItemPicker.ItemsSource = new List<string>
        {
            AppResources.PickerItem1,
            AppResources.PickerItem2,
            AppResources.PickerItem3
        };
    }


    private void OnGreetClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            StatusLabel.Text = string.Format(AppResources.StatusGreeted, NameEntry.Text);
            StatusLabel.TextColor = Colors.Green;
        }
        else
        {
            StatusLabel.Text = AppResources.StatusDefault;
            StatusLabel.TextColor = Colors.Red;
        }
    }

  
    private void OnSwitchToggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            BackgroundColor = Color.FromArgb("#E8F5E9");
            StatusLabel.Text = AppResources.SwitchOn;
            StatusLabel.TextColor = Colors.Green;
        }
        else
        {
            BackgroundColor = Colors.Transparent;
            StatusLabel.Text = AppResources.SwitchOff;
            StatusLabel.TextColor = Colors.Gray;
        }
    }

  
    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        int value = (int)Math.Round(e.NewValue);
        StatusLabel.Text = $"Выбрано значение: {value}";
        StatusLabel.TextColor = Colors.Orange;
    }

   
    private void OnPickerChanged(object sender, EventArgs e)
    {
        if (ItemPicker.SelectedItem != null)
        {
            StatusLabel.Text = $"Выбран: {ItemPicker.SelectedItem}";
            StatusLabel.TextColor = Colors.Blue;
        }
    }

  
    private void OnCounterClicked(object sender, EventArgs e)
    {
        _count++;
        CounterButton.Text = $"{AppResources.ButtonCounter} ({_count})";
    }

   
    private void OnSwitchToRussian(object sender, EventArgs e)
    {
        SetCulture(new CultureInfo("ru"));
    }

  
    private void OnSwitchToSpanish(object sender, EventArgs e)
    {
        SetCulture(new CultureInfo("es"));
    }

    private void SetCulture(CultureInfo culture)
    {
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

       
        if (Application.Current?.Windows.Count > 0)
        {
            Application.Current.Windows[0].Page = new MainPage();
        }
    }
}