using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProductsApp.Core.Services;

namespace ProductsApp.Core.Entities
{
    public class StatisticResponse
    {
        public double Average { get; set; }

        public double Variance { get; set; }

        public double Median { get; set; }

        public StatisticResponse(IEnumerable<int> statistics)
        {
            var listOfDouble = statistics.Select(x => (double) x).ToList();
            Average = Statistic.GetAverage(listOfDouble);
            Variance = Statistic.GetVariance(listOfDouble);
            Median = Statistic.GetMedian(listOfDouble);
        }

        public StatisticResponse() { }
    }
}