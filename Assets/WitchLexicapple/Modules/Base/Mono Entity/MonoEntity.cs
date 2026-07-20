using EditorAttributes;
using Newtonsoft.Json;
using System;
using UnityEditor;
using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class MonoEntity<T> : MonoBehaviour where T : class
    {
        [SerializeField, ReadOnly] private string id;

        public string Id { get => id; set => id = value; }

        private void OnValidate()
        {
            if (!gameObject.scene.IsValid() || string.IsNullOrEmpty(gameObject.scene.path)) return;

            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString("N");
                EditorUtility.SetDirty(this);
            }
        }

        protected virtual void Start()
        {
            if (SaveManager.Instance.TryLoad(Id, out var json))
            {
                JsonConvert.PopulateObject(json, this);
                OnLoaded();
            }
            else
            {
                Save();
            }
        }

        [Button]
        public void Save()
        {
            var json = JsonConvert.SerializeObject(this);
            SaveManager.Instance.SaveEntity(Id, json);
        }

        protected virtual void OnLoaded()
        {

        }
    }
}
