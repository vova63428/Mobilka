using System.Globalization;

namespace TenElement;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Язык по умолчанию — русский
        var culture = new CultureInfo("ru");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainPage());
    }
}