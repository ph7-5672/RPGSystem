namespace Game.System.Buff;

/// <summary>
/// Buff状态，运行中的可变数据。
/// </summary>
public struct Buff : IBuff
{
    public int BuffId { get; set; }
    public int Interval { get; set; }
    public int Duration { get; set; }
    public int Count { get; set; }
    public int Timestamp { get; set; }
    public int TickTimes { get; set; }
}