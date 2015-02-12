using System;
using System.Linq;
using BggSharp;
using BggSharp.Models;

namespace BggSharpTestHarness
{
    class Program
    {
        static void Main()
        {
            var x = new BggSharpClient();

            var result = x.Plays.GetAll("v3rt1g0").Result;

            var any = result.Where(p => p.Item.Subtypes.Any()).ToList();
            Console.ReadLine();
        }
    }
}
