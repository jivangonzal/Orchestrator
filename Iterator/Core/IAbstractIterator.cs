using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestartorIterator.Core
{
    internal interface IAbstractIterator
    {
        Item First();

        Item Next();

        bool IsDone { get; }
        Item CurrentItem { get; }
    }
}
