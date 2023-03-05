namespace Global.Publisher.Abstract.DataStorages
{
    public interface IDataStorage
    {
        T GetEntry<T>(string key) where T : class;
    }
}