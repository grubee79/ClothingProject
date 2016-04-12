using System;
using Clothes;

namespace HotColdProject.helpers.Implementation
{
    class TemperatureProcessorImplementor : TemperatureProcessor
    {
        public Temperature mapTemperature(string temperature)
        {
            Temperature temp;
            if (temperature.Equals("HOT"))
            {
                temp = Temperature.HOT;
            }
            else if (temperature.Equals("COLD"))
            {
                temp = Temperature.COLD;
            }
            else
            {
                throw new SystemException("Incorrect temperature given: " + temperature + " is not a correct temperature. please use HOT or COLD only");
            }

            return temp;
        }
    }
}
