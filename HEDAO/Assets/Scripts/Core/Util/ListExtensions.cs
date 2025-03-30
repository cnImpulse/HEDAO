using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public static class ListExtensions
{
    private static readonly Random _random = new Random();
    private static readonly ThreadLocal<Random> _threadLocalRandom =
        new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

    /// <summary>
    /// 从列表中随机获取一个元素
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    /// <param name="list">目标列表</param>
    /// <returns>随机元素</returns>
    /// <exception cref="InvalidOperationException">列表为空时抛出异常</exception>
    public static T GetRandom<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            throw new InvalidOperationException("列表不能为空且必须包含至少一个元素");
        }

        int randomIndex = _random.Next(0, list.Count);
        return list[randomIndex];
    }

    /// <summary>
    /// 从列表中获取指定数量的不重复随机元素
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    /// <param name="list">目标列表</param>
    /// <param name="count">需要获取的元素数量</param>
    /// <returns>随机元素集合</returns>
    public static List<T> GetRandom<T>(this List<T> list, int count)
    {
        // 参数校验
        if (list == null) throw new ArgumentNullException(nameof(list));
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
        if (count == 0) return new List<T>();

        // 动态调整实际获取数量
        int actualCount = Math.Min(count, list.Count);

        // 复制列表避免修改原数据
        List<T> shuffledList = new List<T>(list);
        Random random = _threadLocalRandom.Value;

        // Fisher-Yates洗牌算法
        for (int i = shuffledList.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            T temp = shuffledList[i];
            shuffledList[i] = shuffledList[j];
            shuffledList[j] = temp;
        }

        return shuffledList.Take(actualCount).ToList();
    }
}