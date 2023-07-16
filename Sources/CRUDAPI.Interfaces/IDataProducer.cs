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

    public interface IDataProducer<T>
    {
        void Init(IDataProducerParams initParams);
        T NextValue();
    }
}
