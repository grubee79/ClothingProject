using Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.validators.Implementation
{
    class DuplicateClothesImplementor : DuplicateItemsValidator<Person>, ValidatorItem<Person>
    {

        public Boolean areThereDuplicates(Person person)
        {
            List<MorningStep> morningSteps = person.getMorningSteps();

            foreach (MorningStep clothes in morningSteps)
            {
                int count = 0;
                foreach (MorningStep step in morningSteps)
                {
                    if (clothes == step)
                        count++;
                }
                if (count > 1) return true;
            }

            return false;
        }

        public int findBadItemIndexOrReturnCountIfValid(Person person)
        {
            if (!validate(person))
            {
                List<MorningStep> morningSteps = person.getMorningSteps();

                foreach (MorningStep clothes in morningSteps)
                {
                    int count = 0;
                    foreach (MorningStep step in morningSteps)
                    {
                        if (clothes == step)
                            count++;
                    }
                    if (count > 1) return morningSteps.LastIndexOf(clothes);
                }
            }

            return person.getMorningSteps().Count();
        }

        public Boolean validate(Person person)
        {
            if (areThereDuplicates(person))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
