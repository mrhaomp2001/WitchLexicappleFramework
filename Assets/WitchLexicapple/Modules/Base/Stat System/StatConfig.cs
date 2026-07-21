using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    [CreateAssetMenu(fileName = "StatConfig", menuName = "Witch Lexicapple/Stat Config")]
    public class StatConfig : ScriptableObject
    {
        [SerializeField] private StatList stats = new();

        public StatList Stats => stats;
    }
}
