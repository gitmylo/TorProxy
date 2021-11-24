using System;
using System.Threading.Tasks;
using Knapcode.TorSharp;

namespace TorProxy.Commands
{
    public class Command
    {
        protected TorSharpProxy proxy;
        protected TorSharpSettings settings;
        public String name, helpInfo;
        public Command(String name, String helpInfo, TorSharpProxy proxy, TorSharpSettings settings)
        {
            this.name = name;
            this.helpInfo = helpInfo;
            this.proxy = proxy;
            this.settings = settings;
        }
        public virtual void run(String command)
        {
            
        }
    }
}