﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotColdProject.validators
{
    public interface LeaveTheHouseValidator<T>
    {
        Boolean ableToLeaveHouse(T person);
    }
}
