using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.validators
{
    public interface ValidatorItem<T>
    {
        Boolean validate(T person);
        int findBadItemIndexOrReturnCountIfValid(T person);
    }
}
