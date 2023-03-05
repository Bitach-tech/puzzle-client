using System;
using System.Collections.Generic;
using Global.Publisher.Yandex.DataStorages;
using Newtonsoft.Json;
using UnityEngine;

namespace Global.Publisher.Abstract.Saves
{
    [Serializable]
    public class LevelsSave : IStorageEntry
    {
        private Dictionary<int, bool> _levels = new();

        public string Key => SavesPaths.Levels;
        public event Action Changed;

        public void CreateDefault()
        {
            _levels = new Dictionary<int, bool>();
        }

        public string Serialize()
        {
            var raw = JsonConvert.SerializeObject(_levels);
            Debug.Log($"Serialize: {raw}");

            return raw;
        }

        public void Deserialize(string raw)
        {
            _levels = JsonConvert.DeserializeObject<Dictionary<int, bool>>(raw);

            Debug.Log($"Deserialize: {raw}");
        }

        public void OnRewarded(int index)
        {
            _levels[index] = true;

            Debug.Log($"On rewarded: {index}");

            Changed?.Invoke();
        }

        public bool IsRewarded(int index)
        {
            if (_levels.ContainsKey(index) == false)
                return false;

            return _levels[index];
        }
    }
}