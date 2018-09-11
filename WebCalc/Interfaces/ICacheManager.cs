namespace WebCalc.Interfaces
{
    public interface ICacheManager
    {
        void Insert(string key, decimal value);
        decimal Get(string key);
        bool Exist(string key);
    }
}
