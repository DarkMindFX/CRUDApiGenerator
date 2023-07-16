using CRUDAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataProducer
{
    public class IntDataProducerParams<T> : IDataProducerParams
    {
        public T RangeStart { get; set; }
        public T RangeEnd { get; set; }
    }

    public class IntDataProducer<T> : IDataProducer<T> 
    {
        private IntDataProducerParams<T> _initParams;
        private HashSet<System.Type> _typesSupported;
        private Random _rnd;

        public IntDataProducer()
        {
            InitTypesSupported();

            if(!_typesSupported.Contains(typeof(T)))
            {
                throw new ArgumentException($"Type {typeof(T).FullName} is not supported by IntDataProducer. Supported types are: { string.Join(", ", _typesSupported) }");
            }

            _rnd = new Random(DateTime.Now.Millisecond);
        }

        public void Init(IDataProducerParams initParams) => _initParams = initParams as IntDataProducerParams<T>;

        public T NextValue()
        {
            return (T)Convert.ChangeType(
                                _rnd.Next(   (int)Convert.ChangeType(_initParams.RangeStart, typeof(int)), 
                                (int)Convert.ChangeType(_initParams.RangeEnd, typeof(int))), 
                                typeof(T));
        }

        #region Support methods
        private void InitTypesSupported()
        {
            _typesSupported = new HashSet<Type>();
            _typesSupported.Add(typeof(Int16));
            _typesSupported.Add(typeof(Int32));
            _typesSupported.Add(typeof(Int64));
        }

       
        #endregion
    }
}
