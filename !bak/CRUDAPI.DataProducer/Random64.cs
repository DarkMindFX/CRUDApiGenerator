using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataProducer
{
    public class Random64
    {
        private Random _random;

        public Random64(Random random)
        {
            _random = random;
        }

        public long Next()
        {
            return Next(Int64.MaxValue);
        }

        public long Next(long maxValue)
        {
            return Next(0, maxValue);
        }

        public long Next(long minValue, long maxValue)
        {
            return (long)(_random.NextDouble() * ((double)maxValue - (double)minValue)) + minValue;
        }
    }
}
