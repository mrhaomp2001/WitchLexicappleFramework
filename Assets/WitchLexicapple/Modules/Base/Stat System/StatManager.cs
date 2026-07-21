using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    public class StatManager : Singleton<StatManager>
    {
        [SerializeField] private StatConfig config;
        [SerializeField] private StatList stats = new();

        public StatList Stats => stats;

        protected override void Awake()
        {
            base.Awake();

            if (config != null)
                stats = config.Stats.Clone();
        }

        public static float GetStat(StatKey key) => Instance.stats[key];
    }
}
