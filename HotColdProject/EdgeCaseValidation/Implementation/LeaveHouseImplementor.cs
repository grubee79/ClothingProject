using Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.validators.Implementation
{
    class LeaveHouseImplementor : LeaveTheHouseValidator<Person>, ValidatorItem<Person>
    {
        public Boolean ableToLeaveHouse(Person person)
        {
            List<MorningStep> morningSteps = person.getMorningSteps();
            if (!leavingBeforeDressed(morningSteps) &&
                    numClothingItemsCorrect(person))
            {
                return true;
            }

            return false;
        }

        //validates that leaving the house is in the arguments and is the final step
        private Boolean leavingBeforeDressed(List<MorningStep> morningSteps)
        {
            if (morningSteps.Count() > 0 &&
                    morningSteps.Contains(MorningStep.LEAVE_HOUSE) &&
                    morningSteps.ElementAt(morningSteps.Count() - 1) != MorningStep.LEAVE_HOUSE) return true;
            return false;
        }

        //should have different amounts of clothing depending on temperature outside
        private Boolean numClothingItemsCorrect(Person person)
        {
            if (person.getTemperature() == Temperature.COLD)
            {
                if (person.getMorningSteps().Count() != 8)
                    return false;
            }
            else
            {
                if (person.getMorningSteps().Count() != 6)
                    return false;
            }
            return true;
        }

        public int findBadItemIndexOrReturnCountIfValid(Person person)
        {
            if (!validate(person))
            {
                List<MorningStep> morningSteps = person.getMorningSteps();

                if (morningSteps.Count() > 0 &&
                        morningSteps.Contains(MorningStep.LEAVE_HOUSE) &&
                        morningSteps.ElementAt(morningSteps.Count() - 1) != MorningStep.LEAVE_HOUSE)
                    return morningSteps.IndexOf(MorningStep.LEAVE_HOUSE);

                if (morningSteps.Contains(MorningStep.LEAVE_HOUSE) &&
                        !numClothingItemsCorrect(person))
                    return morningSteps.IndexOf(MorningStep.LEAVE_HOUSE);

            }

            return person.getMorningSteps().Count();
        }

        public Boolean validate(Person person)
        {
            return ableToLeaveHouse(person);
        }

    }
}
