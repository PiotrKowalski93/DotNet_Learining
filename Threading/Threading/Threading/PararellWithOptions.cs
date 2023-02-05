using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    internal class PararellWithOptions
    {
        public void Main()
        {

        }

        public bool PlinqWithLimits(List<string> items)
        {
            int max = Environment.ProcessorCount > 1 ? Environment.ProcessorCount / 2 : 1;
            return items.AsParallel().WithDegreeOfParallelism(max).Any(x => x.Contains("sth"));
        }

        public void ProcessParallelForEachWithLimits(List<string> items)
        {
            int max = Environment.ProcessorCount > 1 ? Environment.ProcessorCount / 2 : 1;

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = max
            };

            Parallel.ForEach(items, options, x =>
            {
                // process items
            });
        }
    }
}
