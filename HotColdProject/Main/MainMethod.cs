using HotColdProject.factory;
using HotColdProject.factory.Implementation;
using HotColdProject.helpers;
using HotColdProject.helpers.Implementation;
using System;

namespace HotColdProject
{
    class MainMethod
    {
        
        //Add command line arguments in order to test different scenarios
         
        //sets up a person factory to create a person with their morning steps
        private static PersonFactory createPersonFactory()
        {
            ValidatorFactory<Person> personValidationFactory = new PersonValidationFactoryFactory();
            Mapper<Person> personMapper = new StepsForPersonMapper();
            TemperatureProcessor temperatureProcessor = new TemperatureProcessorImplementor();
            PersonFactoryFactory personFactory = new PersonFactoryFactory(personValidationFactory, personMapper, temperatureProcessor);
            return personFactory;
        }

        static void Main(string[] args)
        {
            //add arguments to the command line to test different scenarios
            if (args.Length == 0 || args == null)
            {
                Console.WriteLine("Pass in arguments via command line separated by spaces. All caps for HOT and COLD EX: HOT 8 6 4 2 1 7");
            }

            PersonFactory personFactory = createPersonFactory();
            Person person = personFactory.createPerson(args);
            string results = person.resultOfMyMorningPreparedness();
            Console.WriteLine(results);
        }
        
    }
}
