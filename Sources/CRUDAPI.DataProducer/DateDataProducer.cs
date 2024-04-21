using CRUDAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataProducer
{

    public class DateDataProducerParams : IDataProducerParams
    {
        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }
    }

    public class DateDataProducer : IDataProducer<DateTime>
    {
        private DateDataProducerParams _initParams;
        private double _secDiff = 0;
        private Random64 _rnd;

        public DateDataProducer()
        {
            _rnd = new Random64(new Random(DateTime.Now.Millisecond));
        }

        public void Init(IDataProducerParams initParams)
        {
            _initParams = initParams as DateDataProducerParams;
            if(_initParams == null)
            {
                throw new ArgumentException("Object of type DateDataProducerParams is expected");
            }

            if(_initParams.RangeStart >= _initParams.RangeEnd)
            {
                throw new ArgumentException("Invalid init params: RangeStart must be less than RangeEnd");
            }

            _secDiff = (_initParams.RangeEnd - _initParams.RangeStart).TotalSeconds;
        }

        public DateTime NextValue()
        {
            long addSeconds = _rnd.Next((long)this._secDiff);
            var result = _initParams.RangeStart + TimeSpan.FromSeconds(addSeconds);

            return result;            
        }
    }
}
