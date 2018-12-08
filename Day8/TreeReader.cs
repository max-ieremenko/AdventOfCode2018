using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal static class TreeReader
    {
        public static Node Read(string input)
        {
            var definition = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();

            var fakeRoot = new Node();
            Read(definition, 0, fakeRoot);

            return fakeRoot.Children[0];
        }

        private static int Read(IList<int> definition, int index, Node parent)
        {
            var node = new Node();
            parent.Children.Add(node);

            var childrenCount = definition[index];
            var metadataEntriesCount = definition[index + 1];
            index += 2;

            for (var i = 0; i < childrenCount; i++)
            {
                index = Read(definition, index, node);
            }

            for (var i = 0; i < metadataEntriesCount; i++)
            {
                node.MetadataEntries.Add(definition[index]);
                index++;
            }

            return index;
        }
    }
}
