using System;

namespace Game.System.Buff;

/// <summary>
/// 以静态扩展方法作为api接入。
/// </summary>
public static class BuffExtension
{
    private const int defaultSize = 128;

    /// <summary>
    /// 公开委托作为事件。
    /// </summary>
    public static Action<IBuffOwner, IBuff> BuffTick = delegate {};
    
    /// <summary>
    /// 尝试获取Buff。多用于验证是否持有buff。
    /// </summary>
    /// <param name="owner">实体</param>
    /// <param name="buffId">唯一标识</param>
    /// <param name="buff">获取到的buff状态数据</param>
    /// <returns></returns>
    public static bool TryGetBuff(this IBuffOwner owner, int buffId, out IBuff buff)
    {
        if (owner.Buffs != null && owner.Buffs.Length > buffId)
        {
            buff = owner.Buffs[buffId];
            return buff != null;
        }

        buff = default;
        return false;
    }

    /// <summary>
    /// 为实体添加Buff。
    /// 已拥有buff时，默认重置持续时间。
    /// </summary>
    /// <param name="owner">实体</param>
    /// <param name="buffId">唯一标识</param>
    /// <param name="interval">buff触发效果的间隔时间</param>
    /// <param name="duration">buff持续时间</param>
    /// <param name="count">buff层数</param>
    public static void AddBuff(this IBuffOwner owner, int buffId, int interval = 0, int duration = 0, int count = 1)
    {
        owner.Buffs ??= new IBuff[defaultSize];

        if (owner.TryGetBuff(buffId, out var buff))
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

    /// <summary>
    /// 移除指定层数的buff。
    /// 默认移除所有层数。
    /// </summary>
    /// <param name="owner">实体</param>
    /// <param name="buffId">唯一标识</param>
    /// <param name="count">层数</param>
    public static void DelBuff(this IBuffOwner owner, int buffId, int count = int.MaxValue)
    {
        if (owner.TryGetBuff(buffId, out var buff))
        {
            buff.Count -= count;
            if (buff.Count <= 0)
            {
                owner.Buffs[buffId] = null;
            }
        }
    }

    /// <summary>
    /// 实体Buff轮询。
    /// 计算buff时间戳，并触发回调。
    /// 到达持续时间上限后，移除buff。
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="delta"></param>
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