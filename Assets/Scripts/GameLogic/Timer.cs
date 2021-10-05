using UnityEngine.Events;

public class Timer
{
    public UnityAction<Timer> TimerFinished = delegate { };

    private float _remainingTime;

    public Timer(float duration)
    {
        _remainingTime = duration;
    }

    public void Tick(float dt)
    {
        if (_remainingTime == 0)
        {
            return;
        }

        _remainingTime -= dt;
        CheckTimer();
    }

    private void CheckTimer()
    {
        if (_remainingTime > 0)
        {
            return;
        }

        _remainingTime = 0;

        TimerFinished.Invoke(this);
    }
}

