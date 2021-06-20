using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestartorIterator.Core
{
    internal interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
}
