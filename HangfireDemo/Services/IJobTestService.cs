namespace HangfireDemo.Services
{
    public interface IJobTestService
    {
        void FireAndForgetJob();

        void RecurringJob();

        void DelayedJob();

        void ContinuationJob();
    }
}
