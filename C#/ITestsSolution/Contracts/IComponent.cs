using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
    public interface IComponent
    {
        string Description { get; }
    }

    public interface IMetadata
    {
        int DoneMethods { get; }
    }
}
