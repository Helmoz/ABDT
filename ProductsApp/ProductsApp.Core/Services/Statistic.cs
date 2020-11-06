using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProductsApp.Core.Channels;
using ProductsApp.Core.Entities;
using Reinforced.Tecture.Aspects.Orm.Commands.Add;
using Reinforced.Tecture.Aspects.Orm.Toolings;
using Reinforced.Tecture.Services;

namespace ProductsApp.Core.Services
{
    public class Statistic : TectureService<Adds<UserSession>>
    {
        private Statistic(){}
        
        public static double GetAverage(IEnumerable<double> source)
        {
            return source.Average();
        }

        public static double GetVariance(IReadOnlyCollection<double> source)
        {
            var average = GetAverage(source);
            return source.Sum(t => Math.Pow(t - average, 2)) / (source.Count > 1 ? source.Count - 1 : 1);
        }

        public static double GetMedian(IEnumerable<double> source)
        {
            var sortedPNumbers = source.OrderBy(x => x).ToList();
            var index = sortedPNumbers.Count / 2;
            
            return sortedPNumbers.Count % 2 != 0 
                ? sortedPNumbers[index] 
                : (sortedPNumbers[index] + sortedPNumbers[index - 1]) / 2;
        }

        public void Add(UserSession session)
        {
            To<Db>().Add(session);
        }
    }
}