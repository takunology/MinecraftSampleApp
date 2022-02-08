using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Threading.Tasks;

namespace MinecraftApps.Pages
{
    public sealed partial class GiveItemCommandPage : Page
    {
        Bindings.GiveItemBinding Binding { get; } = new Bindings.GiveItemBinding();

        public GiveItemCommandPage()
        {
            this.InitializeComponent();
        }

        private async void OnCopyButtonClicked(object sender, RoutedEventArgs e)
        {
            ToolTip toolTip = new ToolTip()
            {
                Content = "コピーしました！",
                Placement = Microsoft.UI.Xaml.Controls.Primitives.PlacementMode.Top,
            };

            ToolTipService.SetToolTip(this.copyButton, toolTip);
            toolTip.IsOpen = true;
            await Task.Delay(2000);
            toolTip.IsOpen = false;
        }
    }
}
