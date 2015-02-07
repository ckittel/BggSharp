using System;
using BggSharp;
using BggSharp.Models;

namespace BggSharpTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new BggSharpClient();

            var result = x.HotItems.Get(HotItemType.Boardgame).Result;

            Console.ReadLine();
        }
    }
}
