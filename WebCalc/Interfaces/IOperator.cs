namespace WebCalc.Interfaces
{
    public interface IOperator<T> where T : struct
    {
        
        string Name { get; }
        T Calculate(T operand1, T operand2);
    }
}
