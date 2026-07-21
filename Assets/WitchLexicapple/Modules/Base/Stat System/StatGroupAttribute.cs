using System;

namespace MysticalDreamers.WitchLexicapple
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StatGroupAttribute : Attribute
    {
        public string Group { get; }

        public StatGroupAttribute(string group)
        {
            Group = group;
        }
    }
}
