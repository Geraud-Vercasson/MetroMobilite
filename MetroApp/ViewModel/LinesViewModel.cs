using MetroMobilite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApp.ViewModel
{
    class LinesViewModel
    {
        private List<Line> _Lines = new List<Line>();

        public List<Line> Lines { get => _Lines; set => _Lines = value; }
    }
}
