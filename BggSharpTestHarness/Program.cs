using System;
using System.Linq;
using BggSharp;

namespace BggSharpTestHarness
{
    class Program
    {
        static void Main()
        {
            var x = new BggSharpClient();

            //var result = x.HotItems.Get(HotItemType.Boardgame).Result;

            var result = x.Plays.Get(null, 2, "family", DateTime.MinValue, DateTime.MaxValue, "boardgame", 1).Result.Plays
                .Concat(x.Plays.Get(null, 2, "family", DateTime.MinValue, DateTime.MaxValue, "boardgame", 2).Result.Plays)
                .Concat(x.Plays.Get(null, 2, "family", DateTime.MinValue, DateTime.MaxValue, "boardgame", 3).Result.Plays)
                .Concat(x.Plays.Get(null, 2, "family", DateTime.MinValue, DateTime.MaxValue, "boardgame", 4).Result.Plays).ToList();

            var total = result.Sum(p => p.Quantity);
            Console.WriteLine(total);

            Console.ReadLine();
        }
    }
}
