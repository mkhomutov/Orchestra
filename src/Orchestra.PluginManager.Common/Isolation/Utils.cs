namespace Orchestra.PluginManager.Common.Isolation
{
    using System.Diagnostics;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Ipc;
    using System.Runtime.Serialization.Formatters;

    public static class Utils
    {
        public static IpcServerChannel RegisterServerChannel(string baseServerName)
        {
            var provider = new BinaryServerFormatterSinkProvider {TypeFilterLevel = TypeFilterLevel.Full};
            var channel = new IpcServerChannel(null, baseServerName + "-" + Process.GetCurrentProcess().Id, provider);
            ChannelServices.RegisterChannel(channel, false);

            return channel;
        }
    };
}
