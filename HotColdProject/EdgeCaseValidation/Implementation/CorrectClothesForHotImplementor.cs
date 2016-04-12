using Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.validators.Implementation
{
    class CorrectClothesForHotImplementor : OutfitTemperatureValidator<Person>, ValidatorItem<Person>
    {
        public int findBadItemIndexOrReturnCountIfValid(Person person)
        {
            if (!validate(person))
            {
                List<MorningStep> morningSteps = person.getMorningSteps();
                int socksIndex = morningSteps.Contains(MorningStep.PUT_ON_SOCKS) ? morningSteps.IndexOf(MorningStep.PUT_ON_SOCKS) : Int32.MaxValue;
                int jacketIndex = morningSteps.Contains(MorningStep.PUT_ON_JACKET) ? morningSteps.IndexOf(MorningStep.PUT_ON_JACKET) : Int32.MaxValue;

                return socksIndex > jacketIndex ? jacketIndex : socksIndex;
            }

            return person.getMorningSteps().Count();
        }

        //if it's cold, jacket and socks need to be on
        public Boolean correctClothesForWeather(Person person)
        {
            List<MorningStep> clothes = person.getMorningSteps();
            if (person.getTemperature() == Temperature.COLD)
            {
                if (!clothes.Contains(MorningStep.PUT_ON_SOCKS) ||
                        !clothes.Contains(MorningStep.PUT_ON_JACKET))
                    return false;
            }

            return true;
        }

        public Boolean validate(Person person)
        {
            return correctClothesForWeather(person);
        }
    }
}
