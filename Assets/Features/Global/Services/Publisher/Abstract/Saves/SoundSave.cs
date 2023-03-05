using System;
using Global.Publisher.Yandex.DataStorages;
using Newtonsoft.Json;

namespace Global.Publisher.Abstract.Saves
{
    [Serializable]
    public class SoundSave : IStorageEntry
    {
        private bool _isMuted = false;

        public string Key => SavesPaths.Sounds;
        public event Action Changed;

        public bool IsMuted => _isMuted;

        public void CreateDefault()
        {
            _isMuted = false;
        }

        public void SwitchMute()
        {
            _isMuted = !_isMuted;

            Changed?.Invoke();
        }

        public string Serialize()
        {
            var raw = JsonConvert.SerializeObject(_isMuted);

            return raw;
        }

        public void Deserialize(string raw)
        {
            _isMuted = JsonConvert.DeserializeObject<bool>(raw);
        }
    }
}