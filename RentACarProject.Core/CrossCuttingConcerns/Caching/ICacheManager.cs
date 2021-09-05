namespace RentACarProject.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration); // örn: key=ICarService.Get, value=data, duration=bellekte kalacak süre
        T Get<T>(string key);
        object Get(string key);
        bool IsAdded(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
