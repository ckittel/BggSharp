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
    }
}