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
        private Dictionary<int, bool> _unlocked = new();
        private Dictionary<int, bool> _assembled = new();

        public string Key => SavesPaths.Levels;
        public event Action Changed;

        public void CreateDefault()
        {
            _unlocked = new Dictionary<int, bool>();
        }

        public string Serialize()
        {
            var save = new
            {
                Unlocked = _unlocked,
                Assembled = _assembled
            };
            
            var raw = JsonConvert.SerializeObject(save);
            Debug.Log($"Serialize: {raw}");

            return raw;
        }

        public void Deserialize(string raw)
        {
            var definition = new
            {
                Unlocked = new Dictionary<int, bool>(),
                Assembled = new Dictionary<int, bool>()
            };
            
            var save = JsonConvert.DeserializeAnonymousType(raw, definition);
            
            _unlocked = save.Unlocked;
            _assembled = save.Assembled;
            
            Debug.Log($"Deserialize: {raw}");
        }

        public void OnUnlocked(int index)
        {
            _unlocked[index] = true;

            Debug.Log($"On unlocked: {index}");

            Changed?.Invoke();
        }
        
        public void OnAssembled(int index)
        {
            _assembled[index] = true;

            Debug.Log($"On assembled: {index}");

            Changed?.Invoke();
        }

        public bool IsRewarded(int index)
        {
            if (_unlocked.ContainsKey(index) == false)
                return false;

            return _unlocked[index];
        }
        
        public bool IsAssembled(int index)
        {
            if (_assembled.ContainsKey(index) == false)
                return false;

            return _assembled[index];
        }
    }
}