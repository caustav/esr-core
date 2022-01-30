namespace esr_core
{
    public interface IESRClient
    {
         Task Publish<T>(T t, string eventTag);
    }
}