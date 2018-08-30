using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobilite
{
    interface ILineProvider
    {
        Dictionary<string, Line> getLines(List<string> LineNames);
    }
}
