using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Knapcode.TorSharp;

namespace TorProxy.Commands.impl
{
    public class NewIp : Command
    {
        public NewIp(TorSharpProxy proxy, TorSharpSettings settings) : base("newip", "Get a new ip address", proxy, settings) {}
        public override async void run(string command)
        {
            await proxy.GetNewIdentityAsync();
            using (HttpClient httpClient = new HttpClient(new HttpClientHandler(){Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxySettings.Port))}))
            {
                Console.WriteLine("TorProxy> # New ip: " + await httpClient.GetStringAsync("http://api.ipify.org"));
            }
            
            base.run(command);
        }
    }
}