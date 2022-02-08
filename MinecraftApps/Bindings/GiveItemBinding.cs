using System;
using Reactive.Bindings;
using System.Reactive.Linq;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;

namespace MinecraftApps.Bindings
{
    public class GiveItemBinding
    {
        public ReactivePropertySlim<string> PlayerName { get; set; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> ItemId { get; set; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<int> Count { get; set; } = new ReactivePropertySlim<int>();

        public ReadOnlyReactivePropertySlim<string> Command => PlayerName
            .CombineLatest(ItemId, Count, (playerName, itemid, count) => $"give {playerName} {itemid} {count}")
            .ToReadOnlyReactivePropertySlim();

        public ReactiveCommand Execute { get; private set; } = new ReactiveCommand();
        public ReactiveCommand CopyCommand { get; private set; } = new ReactiveCommand();
        public IconElement Icon => new SymbolIcon(Symbol.Copy);

        public ReactivePropertySlim<string> Result { get; set; } = new ReactivePropertySlim<string>();

        public GiveItemBinding()
        {
            CopyCommand.Subscribe(_ => Copy2Clipboard());
        }

        private void Copy2Clipboard()
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(Command.Value);
            Clipboard.SetContent(dataPackage);
        }
    }
}
