using Clothes;
using HotColdProject.commands;
using HotColdProject.helpers;
using System;

namespace HotColdProject.factory.Implementation
{
    class PersonFactoryFactory : PersonFactory
    {
        private ValidatorFactory<Person> personValidatorFactory;
        private Mapper<Person> personMapper;
        private TemperatureProcessor temperatureProcessor;

        public PersonFactoryFactory(ValidatorFactory<Person> personValidationFactory, Mapper<Person> personMapper,
                         TemperatureProcessor temperatureProcessor)
        {
            personValidatorFactory = personValidationFactory;
            this.personMapper = personMapper;
            this.temperatureProcessor = temperatureProcessor;
        }

        public Person createPerson(string[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                throw new SystemException("you passed in no arguments, please provide arguments");
            }

            Temperature temperature = temperatureProcessor.mapTemperature(arguments[0]);
            Validator<Person> morningValidator = personValidatorFactory.createValidators();
            Person person = new Person(temperature, morningValidator);

            //create new array with arguments minus the temperature
            string[] steps = new string[arguments.Length - 1];
            Array.Copy(arguments, 1, steps, 0, arguments.Length - 1);

            personMapper.mapArgumentsToSteps(steps, person);

            return person;
        }
    }
}
