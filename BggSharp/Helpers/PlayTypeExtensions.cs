using System;
using BggSharp.Models;

namespace BggSharp.Helpers
{
    internal static class PlayTypeExtensions
    {
        public static string ToApiValue(this PlayType type)
        {
            switch (type)
            {
                case PlayType.Thing:
                    return "thing";
                case PlayType.Family:
                    return "family";
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public static PlayType FromApiValue(this string value)
        {
            if (value.Equals("thing", StringComparison.OrdinalIgnoreCase))
            {
                return PlayType.Thing;
            }

            if (value.Equals("family", StringComparison.OrdinalIgnoreCase))
            {
                return PlayType.Family;
            }

            throw new ArgumentException("value was not one of the expected strings", "value");
        }
    }
}