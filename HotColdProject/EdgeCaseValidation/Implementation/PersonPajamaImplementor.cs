using Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.validators.Implementation
{
    class PersonPajamaImplementor : PajamaValidator<Person>, ValidatorItem<Person>
    {
        //taking off pajamas should be first after temperature
        public Boolean arePajamasOff(Person person)
        {
            List<MorningStep> morningSteps = person.getMorningSteps();
            if (morningSteps.ElementAt(0) != MorningStep.TAKE_OFF_PAJAMAS) return false;
            return true;
        }

        public int findBadItemIndexOrReturnCountIfValid(Person person)
        {
            if (!validate(person))
            {
                List<MorningStep> morningSteps = person.getMorningSteps();
                if (morningSteps.ElementAt(0) != MorningStep.TAKE_OFF_PAJAMAS)
                    return morningSteps.IndexOf(MorningStep.TAKE_OFF_PAJAMAS);
            }

            return person.getMorningSteps().Count();
        }

        public Boolean validate(Person person)
        {
            return arePajamasOff(person);
        }
    }
}
