using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using VirtualCard.Interfaces;

namespace VirtualCard
{
    public class Logger : ILogger
    {
        public void Write(string label, string msg )
        {
             Console.WriteLine( $"{DateTime.Now.ToString("dd/MM/yyy HH:MM:ss:FFF")} {label} {msg}");
        }
    }
}
