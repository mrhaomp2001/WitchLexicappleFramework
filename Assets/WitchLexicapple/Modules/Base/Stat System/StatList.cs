using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    [Serializable]
    public class StatList : IEnumerable<Stat>
    {
        [SerializeField] private List<Stat> stats = new();

        public int Count => stats.Count;

        public bool Contains(string key) => stats.Exists(stat => stat.Key == key);

        public void Add(Stat stat) => stats.Add(stat);

        public StatList Clone()
        {
            var clone = new StatList();

            foreach (var stat in stats)
                clone.Add(new Stat(stat.Key, stat.Value, stat.Label));

            return clone;
        }

        public float this[string key]
        {
            get
            {
                var stat = stats.Find(s => s.Key == key);

                if (stat == null)
                    throw new KeyNotFoundException($"Stat '{key}' was not found.");

                return stat.Value;
            }
            set
            {
                var stat = stats.Find(s => s.Key == key);

                if (stat != null)
                    stat.Value = value;
                else
                    stats.Add(new Stat(key, value));
            }
        }

        public float this[StatKey key]
        {
            get => this[ToKeyString(key)];
            set => this[ToKeyString(key)] = value;
        }

        public IEnumerator<Stat> GetEnumerator() => stats.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static string ToKeyString(StatKey key)
        {
            var name = key.ToString();
            return char.ToLowerInvariant(name[0]) + name[1..];
        }
    }
}
