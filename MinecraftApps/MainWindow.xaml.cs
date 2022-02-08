using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace MinecraftApps
{
    public sealed partial class MainWindow : Window
    {
        Bindings.MainWIndowBinding Binding { get; } = new Bindings.MainWIndowBinding();

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            _ = args.SelectedItemContainer.Tag.ToString() switch
            {
                "HomePage" => frame.Navigate(typeof(Pages.HomePage)),
                "TpCommandPage" => frame.Navigate(typeof(Pages.TpCommandPage)),
                "GiveItemCommandPage" => frame.Navigate(typeof(Pages.GiveItemCommandPage)),
                _ => frame.Navigate(typeof(Pages.HomePage))
            };

            if (args.IsSettingsSelected) frame.Navigate(typeof(Pages.SettingsPage));
        }
    }
}
