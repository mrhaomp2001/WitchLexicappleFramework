using Newtonsoft.Json;
using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    public class TestEntity : MonoEntity<TestEntity>
    {
        [JsonProperty]
        [SerializeField] private int testValue;
    }
}
