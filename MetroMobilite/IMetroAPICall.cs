using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transports
{
    internal interface IMetroAPICall
    {
        T Get<T>(string url);
    }
}