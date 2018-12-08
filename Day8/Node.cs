using System.Collections.Generic;
using System.Linq;

namespace Day8
{
    internal sealed class Node
    {
        public IList<Node> Children { get; } = new List<Node>();

        public IList<int> MetadataEntries { get; } = new List<int>();

        public int SumMetadata()
        {
            var result = MetadataEntries.Sum();
            foreach (var child in Children)
            {
                result += child.SumMetadata();
            }

            return result;
        }

        public int GetValue()
        {
            if (Children.Count == 0)
            {
                return MetadataEntries.Sum();
            }

            var result = 0;
            foreach (var index in MetadataEntries)
            {
                var i = index - 1;
                if (i >= 0 && i < Children.Count)
                {
                    result += Children[i].GetValue();
                }
            }

            return result;
        }
    }
}
