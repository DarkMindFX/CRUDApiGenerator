using CRUDAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataProducer
{
    public class VocabularyDataProducerParams : IDataProducerParams
    {
        public string ConnectionString { get; set; }

        public uint MaxLength { get; set; }

        public string VocabularyName { get; set; }
    }

    public class VocabularyDataProducer : IDataProducer<string>
    {
        private VocabularyDataProducerParams _initParams;
        private Random _rnd;
        public void Init(IDataProducerParams initParams)
        {
            _initParams = initParams as VocabularyDataProducerParams;

            if (string.IsNullOrEmpty(_initParams.ConnectionString))
                throw new ArgumentException("ConnectionString is empty. Provide connection string to DB which contains vocabulary");

            if (string.IsNullOrEmpty(_initParams.VocabularyName))
                throw new ArgumentException("VocabularyName is not provided");

            if (_initParams.MaxLength == 0)
                throw new ArgumentException("MaxLength must be greater than 0");
        }

        public string NextValue()
        {
            throw new NotImplementedException();
        }
    }
}
