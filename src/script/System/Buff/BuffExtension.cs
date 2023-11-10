using System;

namespace Game.System.Buff;

/// <summary>
/// 以静态扩展方法作为api接入。
/// </summary>
public static class BuffExtension
{
    private const int defaultSize = 128;

    public static Action<IBuffOwner, IBuff> BuffTick = delegate {};
    
    public static bool TryGetBuffState(this IBuffOwner owner, int buffId, out IBuff buff)
    {
        if (owner.Buffs != null && owner.Buffs.Length > buffId)
        {
            buff = owner.Buffs[buffId];
            return buff != null;
        }

        buff = default;
        return false;
    }


    public static void AddBuff(this IBuffOwner owner, int buffId, int interval = 0, int duration = 0, int count = 1)
    {
        owner.Buffs ??= new IBuff[defaultSize];

        if (owner.TryGetBuffState(buffId, out var buff))
        {
            buff.Interval = interval;
            buff.Duration = duration; // 默认重置持续时间。
            buff.Count += count;
        }
        else
        {
            buff = new Buff
            {
                BuffId = buffId,
                Interval = interval,
                Duration = duration,
                Count = count
            };
            owner.Buffs[buffId] = buff;
        }
    }


    public static void DelBuff(this IBuffOwner owner, int buffId, int count = int.MaxValue)
    {
        if (owner.TryGetBuffState(buffId, out var buff))
        {
            buff.Count -= count;
            if (buff.Count <= 0)
            {
                owner.Buffs[buffId] = null;
            }
        }
    }


    public static void BuffProcess(this IBuffOwner owner, double delta)
    {
        if (owner.Buffs == null)
        {
            return;
        }

        for (var i = 0; i < owner.Buffs.Length; ++i)
        {
            var buff = owner.Buffs[i];
            if (buff == null)
            {
                continue;
            }

            buff.Timestamp += (int)(delta * 1000d);
            
            if (buff.Timestamp >= buff.Interval * buff.TickTimes)
            {
                ++buff.TickTimes;
                BuffTick(owner, buff);
            }
            
            if (buff.Timestamp >= buff.Duration)
            {
                owner.DelBuff(i);
            }
 
        }
    }

}