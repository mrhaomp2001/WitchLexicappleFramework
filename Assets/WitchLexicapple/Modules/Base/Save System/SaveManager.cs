using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using EditorAttributes;

namespace MysticalDreamers.WitchLexicapple
{
    public class SaveManager : Singleton<SaveManager>
    {
        [SerializeField] private readonly Dictionary<string, string> saves = new();

        public bool TryLoad(string id, out string json)
        {
            return saves.TryGetValue(id, out json);
        }

        public void Save(string id, string json)
        {
            saves[id] = json;
        }

        [Button]
        public void LogSaves()
        {
            Debug.Log($"Save count: {saves.Count}");

            foreach (var pair in saves)
            {
                Debug.Log(
                    $"ID: {pair.Key}\n" +
                    $"JSON:\n{pair.Value}"
                );
            }
        }
    }
}
