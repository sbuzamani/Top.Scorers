namespace Top.Scorers.Domain.Interfaces
{
    public interface ICsvHandler
    {
        IEnumerable<string> Read();
    }
}
