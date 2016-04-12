using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.helpers
{
    public interface Mapper<T>
    {
        void mapArgumentsToSteps(String[] arguments, T person);
    }
}
