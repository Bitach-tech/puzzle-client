using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Yandex.Common;
using Global.Setup.Service.Callbacks;
using Newtonsoft.Json;

namespace Global.Publisher.Yandex.DataStorages
{
    public class DataStorage : IDataStorage, IGlobalAsyncAwakeListener
    {
        public DataStorage(YandexCallbacks callbacks, IStorageAPI api, IStorageEntry[] entries)
        {
            _callbacks = callbacks;
            _api = api;

            foreach (var entry in entries)
            {
                entry.Changed += OnEntryChanged;
                _entries[entry.Key] = entry;
            }
        }

        private readonly YandexCallbacks _callbacks;
        private readonly IStorageAPI _api;

        private readonly Dictionary<string, IStorageEntry> _entries = new();

        public async UniTask OnAwakeAsync()
        {
            var completion = new UniTaskCompletionSource();

            foreach (var (_, entry) in _entries)
                entry.CreateDefault();

            void OnReceived(string raw)
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(raw);

                foreach (var (key, rawEntry) in data)
                    _entries[key].Deserialize(rawEntry);

                completion.TrySetResult();
            }

            _callbacks.UserDataReceived += OnReceived;

            _api.Get_Internal();

            await completion.Task;

            _callbacks.UserDataReceived -= OnReceived;
        }

        public T GetEntry<T>(string key) where T : class
        {
            var entry = _entries[key];

            return entry as T;
        }

        private void OnEntryChanged()
        {
            var save = new Dictionary<string, string>();

            foreach (var (key, entry) in _entries)
            {
                var rawEntry = entry.Serialize();
                save[key] = rawEntry;
            }

            var json = JsonConvert.SerializeObject(save);

            _api.Set_Internal(json);
        }
    }
}