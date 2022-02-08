using System;
using System.Reactive.Linq;
using Microsoft.UI.Xaml.Controls;
using Reactive.Bindings;
using Windows.ApplicationModel.DataTransfer;

namespace MinecraftApps.Bindings
{
    public class TpCommandBinding
    {
        public ReactivePropertySlim<int> X { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> Y { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> Z { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<string> PlayerName { get; set; } = new ReactivePropertySlim<string>();
        public ReactiveCommand CopyCommand { get; private set; } = new ReactiveCommand();

        public IconElement Icon => new SymbolIcon(Symbol.Copy);

        public ReadOnlyReactivePropertySlim<string> Command => X
            .CombineLatest(Y, Z, PlayerName, (x, y, z, playerName) => $"tp {playerName} {x} {y} {z}")
            .ToReadOnlyReactivePropertySlim();

        public TpCommandBinding()
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
