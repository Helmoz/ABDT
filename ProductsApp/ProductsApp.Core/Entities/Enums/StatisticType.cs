using System;

namespace ProductsApp.Core.Entities.Enums
{
    public enum StatisticType
    {
        Day,
        Month,
        Year
    }
    
    public static class StatisticTypeExtensions
    {
        public static string ToDisplayString(this StatisticType type)
        {
            return type switch
            {
                StatisticType.Day => "За день",
                StatisticType.Month => "За месяц",
                StatisticType.Year => "За год",
                _ => throw new ArgumentOutOfRangeException()
            }; 
        }
    }
}