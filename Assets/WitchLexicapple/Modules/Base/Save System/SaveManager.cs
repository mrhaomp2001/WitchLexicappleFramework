using EditorAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    [Serializable]
    public class SaveFile
    {
        [JsonProperty]
        public Dictionary<string, string> entities = new();
    }

    public class SaveManager : Singleton<SaveManager>
    {
        private SaveFile currentSave = new();

        [SerializeField] private string CurrentSaveName;

        private static readonly JsonSerializerSettings JsonSettings = new()
        {
            Formatting = Formatting.Indented
        };

        private string SaveFolder =>
            Path.Combine(Application.persistentDataPath, "saves");

        public bool TryLoad(string id, out string json)
        {
            return currentSave.entities.TryGetValue(id, out json);
        }

        public void SaveEntity(string id, string json)
        {
            currentSave.entities[id] = json;
        }

        public void CreateNewSave()
        {
            CurrentSaveName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            currentSave = new SaveFile();
        }
        [Button]
        public void Save()
        {
            if (string.IsNullOrEmpty(CurrentSaveName))
                CreateNewSave();

            if (!Directory.Exists(SaveFolder))
                Directory.CreateDirectory(SaveFolder);

            string path = Path.Combine(
                SaveFolder,
                CurrentSaveName + ".json");

            string json = JsonConvert.SerializeObject(
                currentSave,
                JsonSettings);

            File.WriteAllText(path, json);
        }
        [Button]
        public bool Load(string saveName)
        {
            string path = Path.Combine(
                SaveFolder,
                saveName + ".json");

            if (!File.Exists(path))
                return false;

            string json = File.ReadAllText(path);

            JsonConvert.PopulateObject(
                json,
                currentSave,
                new JsonSerializerSettings
                {
                    ObjectCreationHandling = ObjectCreationHandling.Replace
                });

            CurrentSaveName = saveName;

            return true;
        }

        [Button]
        public List<string> GetSaveList()
        {
            if (!Directory.Exists(SaveFolder))
                return new List<string>();

            List<string> saves = new();

            foreach (string file in Directory.GetFiles(SaveFolder, "*.json"))
            {
                saves.Add(Path.GetFileNameWithoutExtension(file));

                Debug.Log($"Found save: {Path.GetFileNameWithoutExtension(file)}");
            }

            return saves;
        }

        [Button]
        public void LogSaves()
        {
            Debug.Log($"Save count: {currentSave.entities.Count}");

            foreach (var pair in currentSave.entities)
            {
                Debug.Log($"ID: {pair.Key} - JSON: {pair.Value}");
            }
        }
    }
}
