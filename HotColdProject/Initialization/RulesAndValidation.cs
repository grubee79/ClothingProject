using HotColdProject.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.commands
{
    class RulesAndValidation : Validator<Person>
    {
        private List<ValidatorItem<Person>> validationElements;

        public void rulesForValidation(List<ValidatorItem<Person>> validationElements)
        {
            this.validationElements = validationElements;
        }
        
        public Boolean validate(Person person)
        {
            foreach (ValidatorItem<Person> validationElement in validationElements)
            {
                Boolean isValid = validationElement.validate(person);
                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
      
        public int checkForBadIndexValue(Person person)
        {
            foreach (ValidatorItem<Person> validationElement in validationElements)
            {
                Boolean isValid = validationElement.validate(person);
                if (!isValid)
                {
                    return validationElement.findBadItemIndexOrReturnCountIfValid(person);
                }
            }

            return person.getMorningSteps().Count;
        }
    }
}
