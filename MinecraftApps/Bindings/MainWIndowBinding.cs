using Microsoft.UI.Xaml.Controls;
using Reactive.Bindings;

namespace MinecraftApps.Bindings
{
    public class MainWIndowBinding
    {
        public ReactivePropertySlim<Page> PageContent { get; set; } = new ReactivePropertySlim<Page>(new Pages.HomePage());
    }
}
