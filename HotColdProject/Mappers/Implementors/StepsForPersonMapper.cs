using Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.helpers.Implementation
{
    class StepsForPersonMapper : Mapper<Person>
    {
        public void mapArgumentsToSteps(string[] arguments, Person person)
        {
            foreach(string step in arguments){
                person.addMorningSteps(MorningStep.getStep(Int32.Parse(step)));
            }
        }
    }
}
