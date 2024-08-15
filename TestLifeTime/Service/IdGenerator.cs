namespace TestLifeTime.Service
{
    public class IdGenerator
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
