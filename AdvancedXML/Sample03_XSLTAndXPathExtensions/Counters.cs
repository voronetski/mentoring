using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample03_XSLTAndXPathExtensions
{
    public class Counters
    {
        private Dictionary<string, int> counters = new Dictionary<string, int>();

        public int GetAndInc(string name)
        {
            int result = 0;
            counters.TryGetValue(name, out result);
            counters[name] = result + 1;
            return result;
        }
    }
}
