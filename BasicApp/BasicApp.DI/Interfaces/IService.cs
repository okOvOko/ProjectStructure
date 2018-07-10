namespace BasicApp.DI.Interfaces
{
    public interface IService
    {
        int SingletonNumber { get; }
        int ScopedNumber { get; }
        int TransientNumber { get; }
    }
}