namespace PollyExample
{
    public interface ISomeService
    {
        string DoSomething(CancellationToken cancellationToken);
    }
}
