namespace WebCalc.Interfaces
{
    public interface IOperatorFactory
    {
        IOperator<decimal> Build(string sign);
    }
}
