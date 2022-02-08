using Microsoft.UI.Xaml.Controls;

namespace MinecraftApps.Pages
{
    public sealed partial class SettingsPage : Page
    {
        Bindings.SettingsBinding Binding { get; } = new Bindings.SettingsBinding();
        
        public SettingsPage()
        {
            this.InitializeComponent();
        }
    }
}
