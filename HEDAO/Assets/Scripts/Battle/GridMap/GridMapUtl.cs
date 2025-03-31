using UnityEngine;
using System.Collections.Generic;

public static class GridMapUtl
{
    /// <summary>
    /// 计算曼哈顿距离
    /// </summary>
    public static int GetDistance(Vector2Int pos1, Vector2Int pos2)
    {
        return Mathf.Abs(pos1.x - pos2.x) + Mathf.Abs(pos1.y - pos2.y);
    }

    /// <summary>
    /// 计算曼哈顿距离
    /// </summary>
    public static int GetDistance(GridData pos1, GridData pos2)
    {
        return GetDistance(pos1.GridPos, pos2.GridPos);
    }

    /// <summary>
    /// 获得更近的网格数据,相同优先返回pos1
    /// </summary>
    public static GridData GetNearestGridData(GridData target, GridData pos1, GridData pos2)
    {
        int dis1 = GetDistance(target, pos1);
        int dis2 = GetDistance(target, pos2);
        return dis1 <= dis2 ? pos1 : pos2;
    }

    private static readonly int maxWidth = 10000;

    public static int GridPosToIndex(Vector2Int gridPos)
    {
        return gridPos.x + gridPos.y * maxWidth;
    }
    
    public static Vector2Int[] s_DirArray8 = {
        Vector2Int.down, // (0, -1)
        Vector2Int.up, // (0, 1)
        Vector2Int.left, // (-1, 0)
        Vector2Int.right, // (1, 0)
        Vector2Int.one, // (1, 1)
        new (1, -1), // (1, -1)
        new (-1, -1), // (-1, -1)
        new (-1, 1) // (-1, 1)
    };
    
    public static Vector2Int NormalizeDirection(Vector2Int dir)
    {
        Vector2Int normalizedDir = Vector2Int.zero;
        float maxDot = float.MinValue;

        foreach (var predefinedDir in s_DirArray8)
        {
            float dot = Vector2.Dot(dir, predefinedDir);
            if (dot > maxDot)
            {
                maxDot = dot;
                normalizedDir = predefinedDir;
            }
        }

        return normalizedDir;
    }
}
