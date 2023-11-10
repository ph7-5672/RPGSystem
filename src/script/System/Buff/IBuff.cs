namespace Game.System.Buff;

public interface IBuff
{
    public int BuffId { get; set; }

    /// <summary>
    /// 间隔时间。
    /// </summary>
    public int Interval { get; set; }

    /// <summary>
    /// 真实持续时间，毫秒为单位。
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// 层数。
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 时间戳。
    /// </summary>
    public int Timestamp { get; set; }

    /// <summary>
    /// 轮询次数。
    /// </summary>
    public int TickTimes { get; set; }
}