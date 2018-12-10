using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Day07
{
    [DebuggerDisplay("{Name}")]
    public sealed class Step
    {
        public Step(string name)
        {
            Name = name;
            DependsOn = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        public string Name { get; }

        public ICollection<string> DependsOn { get; }

        public int Duration { get; set; }
    }
}
