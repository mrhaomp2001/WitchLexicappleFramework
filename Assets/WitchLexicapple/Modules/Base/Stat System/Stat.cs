using System;
using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    [Serializable]
    public class Stat
    {
        [SerializeField] private string key;
        [SerializeField] private string label;
        [SerializeField] private float value;

        public string Key => key;
        public string Label => label;
        public float Value { get => value; set => this.value = value; }

        public Stat(string key, float value = 0f, string label = null)
        {
            this.key = key;
            this.value = value;
            this.label = label;
        }
    }
}
