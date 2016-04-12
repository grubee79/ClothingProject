using System.Collections.Generic;
using HotColdProject.commands;
using HotColdProject.validators;
using HotColdProject.validators.Implementation;

namespace HotColdProject.factory.Implementation
{
    class PersonValidationFactoryFactory : ValidatorFactory<Person>
    {
        
        public Validator<Person> createValidators()
        {
            Validator<Person> rulesAndValidation;

            rulesAndValidation = new RulesAndValidation();

            List<ValidatorItem<Person>> stepsToBeValidated = new List<ValidatorItem<Person>>();

            stepsToBeValidated.Add(new StepsOrdersImplementor());
            stepsToBeValidated.Add(new PersonPajamaImplementor());
            stepsToBeValidated.Add(new CorrectClothesForHotImplementor());
            stepsToBeValidated.Add(new LeaveHouseImplementor());
            stepsToBeValidated.Add(new DuplicateClothesImplementor());

            rulesAndValidation.rulesForValidation(stepsToBeValidated);

            return rulesAndValidation;
        }
    }
}
