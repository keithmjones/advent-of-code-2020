using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class LuggageProcessor
    {
        public Dictionary<string, Bag> Bags = new Dictionary<string, Bag>();

        public Bag GetBag(string name)
        {
            if (!Bags.ContainsKey(name)) Bags[name] = new Bag(name);
            return Bags[name];
        }

        public void ParseInput(string input)
        {
            var idx = input.IndexOf(" bags contain ");
            if (idx > 0)
            {
                var name = input.Substring(0, idx);
                var bag = GetBag(name);
                var idx1 = idx + 14;
                if (Char.IsDigit(input[idx1]))
                {
                    bag.AddContents(input.Substring(idx1, input.IndexOf('.') - idx1), this);
                }
            }
        }
    }

    public class Bag
    {
        public string Name;
        public Dictionary<Bag, int> Contents = new Dictionary<Bag, int>();
        public List<Bag> Containers = new List<Bag>();

        public Bag(string name) {
            Name = name;
        }

        public void AddContents(string contents, LuggageProcessor graph)
        {
            var items = contents.Split(", ");
            foreach (var item in items) {
                var space = item.IndexOf(' ');
                var end = item.IndexOf(" bag", space);
                var quantity = Int32.Parse(item.Substring(0, space));
                var bag = graph.GetBag(item.Substring(space + 1, end - (space + 1)));
                bag.AddContainer(this);
                bag.AddContainers(Containers);
                Contents.Add(bag, quantity);
            }
        }

        public void AddContainer(Bag container)
        {
            if (!Containers.Contains(container))
            {
                Containers.Add(container);
            }
            foreach (var item in Contents)
            {
                item.Key.AddContainer(container);
            }
        }

        public void AddContainers(IEnumerable<Bag> containers)
        {
            Containers.AddRange(containers.Where(item => !Containers.Contains(item)));
            foreach (var item in Contents)
            {
                item.Key.AddContainers(containers);
            }
        }

        public Dictionary<Bag, int> GetAllContents()
        {
            var aggregatedContents = new Dictionary<Bag, int>();
            foreach (var item in Contents)
            {
                if (!aggregatedContents.ContainsKey(item.Key)) aggregatedContents[item.Key] = 0;
                aggregatedContents[item.Key] += item.Value;
                foreach (var item2 in item.Key.GetAllContents())
                {
                    var quantity = item.Value * item2.Value;
                    if (!aggregatedContents.ContainsKey(item2.Key)) aggregatedContents[item2.Key] = 0;
                    aggregatedContents[item2.Key] += quantity;
                }
            }
            return aggregatedContents;
        }
    }
}
