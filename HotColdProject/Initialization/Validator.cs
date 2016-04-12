using HotColdProject.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.commands
{
    public interface Validator<T>
    {
        void rulesForValidation(List<ValidatorItem<T>> itemsToValidate);
        Boolean validate(T pesron);
        int checkForBadIndexValue(T person);
    }
}
