using Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.validators.Implementation
{
    class StepsOrdersImplementor : StepOrderValidator<Person>, ValidatorItem<Person>
    {
        //check that all clothes are put on in the correct order
        public Boolean areStepsCorrectOrder(Person person)
        {
            List<MorningStep> morningSteps = person.getMorningSteps();

            if (arePantsBeforeFootWear(morningSteps)) return false;
            if (isShirtBeforeHeadWear(morningSteps)) return false;
            if (isShirtBeforeJacket(morningSteps)) return false;
            if (areSocksBeforeShoes(morningSteps)) return false;


            return true;
        }

        public int findBadItemIndexOrReturnCountIfValid(Person person)
        {
            if (!validate(person))
            {
                List<MorningStep> morningSteps = person.getMorningSteps();

                if (arePantsBeforeFootWear(morningSteps))
                    return morningSteps.IndexOf(MorningStep.PUT_ON_FOOTWEAR);
                if (isShirtBeforeHeadWear(morningSteps))
                    return morningSteps.IndexOf(MorningStep.PUT_ON_HEAD_WEAR);
                if (isShirtBeforeJacket(morningSteps))
                    return morningSteps.IndexOf(MorningStep.PUT_ON_JACKET);
                if (areSocksBeforeShoes(morningSteps))
                    return morningSteps.IndexOf(MorningStep.PUT_ON_FOOTWEAR);
            }

            return person.getMorningSteps().Count();
        }

        //pants go on before shoes
        private Boolean arePantsBeforeFootWear(List<MorningStep> morningSteps)
        {
            if (morningSteps.Contains(MorningStep.PUT_ON_PANTS) && morningSteps.Contains(MorningStep.PUT_ON_FOOTWEAR))
            {
                if (morningSteps.IndexOf(MorningStep.PUT_ON_PANTS) > morningSteps.IndexOf(MorningStep.PUT_ON_FOOTWEAR))
                    return true;
            }
            return false;
        }

        //shirt goes on before hats
        private Boolean isShirtBeforeHeadWear(List<MorningStep> morningSteps)
        {
            if (morningSteps.Contains(MorningStep.PUT_ON_SHIRT) && morningSteps.Contains(MorningStep.PUT_ON_HEAD_WEAR))
            {
                if (morningSteps.IndexOf(MorningStep.PUT_ON_SHIRT) > morningSteps.IndexOf(MorningStep.PUT_ON_HEAD_WEAR))
                    return true;

            }
            return false;
        }

        //shirt goes on before jacket
        private Boolean isShirtBeforeJacket(List<MorningStep> morningSteps)
        {
            if (morningSteps.Contains(MorningStep.PUT_ON_SHIRT) && morningSteps.Contains(MorningStep.PUT_ON_JACKET))
            {
                if (morningSteps.IndexOf(MorningStep.PUT_ON_SHIRT) > morningSteps.IndexOf(MorningStep.PUT_ON_JACKET))
                    return true;
            }
            return false;
        }

        //socks go on before shoes
        private Boolean areSocksBeforeShoes(List<MorningStep> morningSteps)
        {
            if (morningSteps.Contains(MorningStep.PUT_ON_FOOTWEAR) && morningSteps.Contains(MorningStep.PUT_ON_SOCKS))
            {
                if (morningSteps.IndexOf(MorningStep.PUT_ON_SOCKS) > morningSteps.IndexOf(MorningStep.PUT_ON_FOOTWEAR))
                    return true;
            }
            return false;
        }

        public Boolean validate(Person person)
        {
            return areStepsCorrectOrder(person);
        }
    }
}
