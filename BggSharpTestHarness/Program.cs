using System;
using BggSharp;
using BggSharp.Models;

namespace BggSharpTestHarness
{
    class Program
    {
        static void Main()
        {
            var x = new BggSharpClient();

            var result = x.HotItems.Get(HotItemType.Videogame).Result;

            Console.ReadLine();
        }
    }
}
