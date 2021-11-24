using System;
using System.Net;
using System.Net.Http;
using Knapcode.TorSharp;

namespace TorProxy.Commands.impl
{
    public class Ip : Command
    {
        public Ip(TorSharpProxy proxy, TorSharpSettings settings) : base("showip", "Show ip address", proxy, settings) {}
        public override async void run(string command)
        {
            using (HttpClient httpClient = new HttpClient(new HttpClientHandler(){Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxySettings.Port))}))
            {
                Console.WriteLine("TorProxy> # Ip: " + await httpClient.GetStringAsync("http://api.ipify.org"));
            }
            base.run(command);
        }
    }
}