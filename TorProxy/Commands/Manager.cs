using System;
using System.Collections.Generic;
using Knapcode.TorSharp;
using TorProxy.Commands.impl;

namespace TorProxy.Commands
{
    public class Manager
    {
        public static List<Command> CmdList;

        public static void Init(TorSharpProxy proxy, TorSharpSettings settings)
        {
            CmdList = new List<Command>()
            {
                new Help(proxy, settings),
                new NewIp(proxy, settings),
                new Ip(proxy, settings),
            };
        }

        public static void RunCommand(String command)
        {
            bool found=false;
            String startcmd=command.Split(' ')[0];
            foreach (Command cmd in CmdList)
            {
                if (startcmd == cmd.name)
                {
                    cmd.run(command);
                    found = true;break;
                }
            }
            if (!found)
                Console.WriteLine($"! Unknown command {startcmd}. Use 'help' to see a list of commands!");
        }
    }
}