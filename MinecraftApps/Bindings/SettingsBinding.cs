using Reactive.Bindings;
using System;

namespace MinecraftApps.Bindings
{
    public class SettingsBinding
    {
        public ReactivePropertySlim<string> IpAddress { get; set; } = new ReactivePropertySlim<string>(Properties.Settings.Default.IP_ADDRESS);
        public ReactivePropertySlim<ushort> Port { get; set; } = new ReactivePropertySlim<ushort>(Properties.Settings.Default.PORT);
        public ReactivePropertySlim<string> Password { get; set; } = new ReactivePropertySlim<string>(Properties.Settings.Default.PASSWORD);

        public SettingsBinding()
        {
            IpAddress.Subscribe(x =>
            {
                Properties.Settings.Default.IP_ADDRESS = x;
                Properties.Settings.Default.Save();
            });

            Port.Subscribe(x =>
            {
                Properties.Settings.Default.PORT = x;
                Properties.Settings.Default.Save();
            });

            Password.Subscribe(x =>
            {
                Properties.Settings.Default.PASSWORD = x;
                Properties.Settings.Default.Save();
            });
        }
    }
}