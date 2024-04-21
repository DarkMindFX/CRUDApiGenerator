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
        private Random64 _rnd64;

        public IntDataProducer()
        {
            InitTypesSupported();

            if(!_typesSupported.Contains(typeof(T)))
            {
                throw new ArgumentException($"Type {typeof(T).FullName} is not supported by IntDataProducer. Supported types are: { string.Join(", ", _typesSupported) }");
            }

            _rnd = new Random(DateTime.Now.Millisecond);
            _rnd64 = new Random64(_rnd);
        }

        public void Init(IDataProducerParams initParams)
        {
            _initParams = initParams as IntDataProducerParams<T>;

            if (_initParams == null)
            {
                throw new ArgumentException("Object of type IntDataProducerParams<Type> is expected");
            }
        }


        public T NextValue()
        {
            if (typeof(T) == typeof(Int64))
            {
                var rndLong = _rnd64.Next(
                        (long)Convert.ChangeType(_initParams.RangeStart, typeof(long)),
                        (long)Convert.ChangeType(_initParams.RangeEnd, typeof(long))
                    );

                return (T)Convert.ChangeType(rndLong, typeof(T));

            }
            else
            {
                return (T)Convert.ChangeType(
                                    _rnd.Next((int)Convert.ChangeType(_initParams.RangeStart, typeof(int)),
                                    (int)Convert.ChangeType(_initParams.RangeEnd, typeof(int))),
                                    typeof(T));
            }
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
