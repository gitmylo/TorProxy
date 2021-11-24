using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Knapcode.TorSharp;
using TorProxy.Commands;

namespace TorProxy
{
  internal class Program
  {
    public static async Task Main(string[] args)
    {
      // configure
      var settings = new TorSharpSettings
      {
        ZippedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorZipped"),
        ExtractedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorExtracted"),
        PrivoxySettings =
        {
          Port = 1337
        },
        TorSettings =
        {
          SocksPort = 1338,
          ControlPort = 1339,
          ControlPassword = "CHJOIj3?>?>?<?L<}{PFS}15lhoNJS)IVNpjfl?LFJSD?LFJHS?FSDJF;",
        },
      };

      // download tools
      await new TorSharpToolFetcher(settings, new HttpClient()).FetchAsync();

      // execute
      var proxy = new TorSharpProxy(settings);
      var handler = new HttpClientHandler
      {
        Proxy = new WebProxy(new Uri("http://localhost:" + settings.PrivoxySettings.Port))
      };
      await proxy.ConfigureAndStartAsync();
      
      Manager.Init(proxy, settings);
      Console.WriteLine();
      String cmd;
      while (true)
      {
        cmd = Console.ReadLine();
        Manager.RunCommand(cmd);
      }
    }
  }
}