using CRUDAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataProducer
{

    public class StringDataProducerParams : IDataProducerParams
    {
        public uint MaxLength { get; set; }
    }

    public class StringDataProducer : IDataProducer<string>
    {
        private StringDataProducerParams _initParams;
        private Random _rnd;

        public StringDataProducer()
        {
            _rnd = new Random(DateTime.Now.Millisecond);
        }
        public void Init(IDataProducerParams initParams)
        {
            _initParams = initParams as StringDataProducerParams;

            if (_initParams.MaxLength == 0)
                throw new ArgumentException("MaxLength must be greater than 0");
        }

        public string NextValue()
        {
            StringBuilder sb = new StringBuilder();
            int length = _rnd.Next(1, (int)_initParams.MaxLength);
            for(int i = 0; i < length; ++i)
            {
                sb.Append((char)(32 + _rnd.Next(0, 90)));
            }

            return sb.ToString();
        }
    }
}
