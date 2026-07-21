using System.Linq;

namespace MysticalDreamers.WitchLexicapple
{
    public static class StatKeyUtility
    {
        public static string GetGroup(StatKey key)
        {
            var field = typeof(StatKey).GetField(key.ToString());
            var attribute = field?.GetCustomAttributes(typeof(StatGroupAttribute), false)
                .FirstOrDefault() as StatGroupAttribute;

            return attribute?.Group ?? "Other";
        }
    }
}
