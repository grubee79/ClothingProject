using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes
{
    public class Temperature
    {
        public static readonly Temperature HOT = new Temperature("HOT", "HOT");
        public static readonly Temperature COLD = new Temperature("COLD", "COLD");
        public static readonly Temperature INVALID_ARGUMENT = new Temperature("INVALID_ARGUMENT", "INVALID_ARGUMENT");

        public static IEnumerable<Temperature> Temperatures
        {
            get
            {
                yield return HOT;
                yield return COLD;
                yield return INVALID_ARGUMENT;
            }
        }

        private readonly string temperature;
        private readonly string tempDesc;

        Temperature(string temperature, string tempDesc)
        {
            this.temperature = temperature;
            this.tempDesc = tempDesc;
        }

        public static Temperature getTemperature(string tempDesc)
        {
            switch (tempDesc)
            {
                case "COLD": return Temperature.COLD;
                case "HOT": return Temperature.HOT;

                default: return INVALID_ARGUMENT;
            }
        }
    }
}
