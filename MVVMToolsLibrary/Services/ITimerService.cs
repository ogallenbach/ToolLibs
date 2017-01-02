
namespace MVVMTools.Services
{
    /// <summary>
    /// Stellt die Timer-Funktionalität bereit.
    /// </summary>
    public interface ITimerService
    {
        void Start();
        void Stop();
        bool TimerEnabled
        {
            get;
            set;
        }
        int TimerInterval
        {
            get;
            set;
        }
    }
}
