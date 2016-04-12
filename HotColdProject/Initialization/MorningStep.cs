using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes
{
    public class MorningStep
    {
        public static readonly MorningStep PUT_ON_FOOTWEAR = new MorningStep("PUT_ON_FOOTWEAR", "Sandals", "Boots");
        public static readonly MorningStep PUT_ON_SOCKS = new MorningStep("PUT_ON_SOCKS", "Fail", "Socks");
        public static readonly MorningStep PUT_ON_JACKET = new MorningStep("PUT_ON_JACKET", "Fail", "Jacket");
        public static readonly MorningStep PUT_ON_HEAD_WEAR = new MorningStep("PUT_ON_HEAD_WEAR", "Sunglasses", "Hat");
        public static readonly MorningStep PUT_ON_SHIRT = new MorningStep("PUT_ON_SHIRT", "Shirt", "Shirt");
        public static readonly MorningStep PUT_ON_PANTS = new MorningStep("PUT_ON_PANTS", "Shorts", "Pants");
        public static readonly MorningStep TAKE_OFF_PAJAMAS = new MorningStep("TAKE_OFF_PAJAMAS", "Removing PJ's", "Removing PJ's");
        public static readonly MorningStep LEAVE_HOUSE = new MorningStep("LEAVE_HOUSE", "Leaving house", "Leaving house");
        public static readonly MorningStep INCORRECT_ARGUMENT = new MorningStep("INCORRECT_ARGUMENT", "Argument not recognized", "Argument not recognized");


        public static IEnumerable<MorningStep> Values
        {
            get
            {
                yield return PUT_ON_FOOTWEAR;
                yield return PUT_ON_SOCKS;
                yield return PUT_ON_JACKET;
                yield return PUT_ON_HEAD_WEAR;
                yield return PUT_ON_SHIRT;
                yield return PUT_ON_PANTS;
                yield return TAKE_OFF_PAJAMAS;
                yield return LEAVE_HOUSE;
                yield return INCORRECT_ARGUMENT;
            }
        }

        private readonly string stepName;
        private readonly string hotDesc;
        private readonly string coldDesc;

        private static readonly string FAIL = "fail";

        MorningStep(string stepName, string hotDesc, string coldDesc)
        {
            this.stepName = stepName;
            this.hotDesc = hotDesc;
            this.coldDesc = coldDesc;
        }

        public string getStepName { get { return stepName; } }
        public string getHotDesc { get { return hotDesc; } }
        public string getColdDesc { get { return coldDesc; } }

        public string getTempDescription(Temperature temperature)
        {
            if (temperature == Temperature.COLD)
                return getColdDesc;
            else if (temperature == Temperature.HOT)
                return getHotDesc;
            else
                return FAIL;
        }

        public static MorningStep getStep(int stepNum)
        {
            switch (stepNum)
            {
                case 1:
                    return PUT_ON_FOOTWEAR;
                case 2:
                    return PUT_ON_HEAD_WEAR;
                case 3:
                    return PUT_ON_SOCKS;
                case 4:
                    return PUT_ON_SHIRT;
                case 5:
                    return PUT_ON_JACKET;
                case 6:
                    return PUT_ON_PANTS;
                case 7:
                    return LEAVE_HOUSE;
                case 8:
                    return TAKE_OFF_PAJAMAS;
                default:
                    return INCORRECT_ARGUMENT;
            }
                
        }
    }
}
