namespace MysticalDreamers.WitchLexicapple
{
    public static class StatKeyDefaults
    {
        public static float GetDefaultValue(StatKey key) => key switch
        {
            StatKey.MaxHp => 100f,
            StatKey.Speed => 5f,
            _ => 0f,
        };

        public static string GetDefaultLabel(StatKey key) => key switch
        {
            StatKey.MaxHp => "Max HP",
            StatKey.Speed => "Speed",
            _ => key.ToString(),
        };
    }
}
