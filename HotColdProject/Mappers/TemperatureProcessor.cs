using Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.helpers
{
    interface TemperatureProcessor
    {
        Temperature mapTemperature(String temperature);
    }
}
