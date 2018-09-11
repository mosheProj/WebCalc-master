namespace WebCalc.Interfaces
{
    public interface ICalculatotManager<T>
    {
        T Manage(string expression);
    }
}
