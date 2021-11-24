using System;
using Knapcode.TorSharp;

namespace TorProxy.Commands.impl
{
    public class Help : Command
    {
        public Help(TorSharpProxy proxy, TorSharpSettings settings) : base("help", "Shows this message", proxy, settings) {}

        public override void run(string command)
        {
            String help = "--------------------------\n";
            foreach (Command c in Manager.CmdList)
            {
                help += $"{c.name} : {c.helpInfo}\n";
            }

            help += $"\nConnect to the proxy on localhost:{settings.TorSettings.SocksPort} as a socks5 proxy, for .onion domains make sure to allow the proxy on dns as well\n";
            help += "--------------------------";
            Console.WriteLine(help);
            base.run(command);
        }
    }
}