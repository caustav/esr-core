using esr_core;

namespace console_client
{
    public class ConsoleObserver : IESRObserver
    {
        public Task OnNotify(string strEvent)
        {
            System.Console.WriteLine(strEvent);
            return Task.CompletedTask;
        }
    }
}