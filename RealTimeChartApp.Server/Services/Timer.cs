namespace RealTimeChartApp.Server.Services;

public class TimerManager
{
    private Timer timer;
    private AutoResetEvent autoResetEvent;
    private Action action;
    public DateTime TimerStarted { get; set; }
    public bool IsTimerStarted { get; set; }

    public void PrepareTimer(Action action)
    {
        this.action = action;
        autoResetEvent = new AutoResetEvent(false);
        timer = new Timer(Execute, autoResetEvent, 5000, 5000);
        TimerStarted = DateTime.Now;
        IsTimerStarted = true;
    }

    public void Execute(object stateInfo)
    {
        action();

        if ((DateTime.Now - TimerStarted).TotalSeconds > 60)
        {
            IsTimerStarted = false;
            timer.Dispose();
        }
    }
}
