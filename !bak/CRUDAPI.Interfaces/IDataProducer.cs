using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Interfaces
{
    public interface IDataProducerParams
    {
    }

    public interface IDataProducer
    {
        void Init(IDataProducerParams initParams);
    }

    public interface IDataProducer<T> : IDataProducer
    {        
        T NextValue();
    }
}
