using UnityEngine;

public class MathHelper
{
    public static float GetAngle(Vector3 v)
    {
        float a = Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
        a %= 360;
        if (a < 0)
            a += 360;

        return a;
    }

    public static Vector3 GetPointOnCircle(float angle, float radius, Vector3? center)
    {
        Vector3 result = new Vector3();
        Vector3 c = (center.HasValue) ? center.Value : Vector3.zero;
        result.x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius + c.x;
        result.z = Mathf.Sin(angle * Mathf.Deg2Rad) * radius + c.z;

        return result;

    }

    public static float GetNearestDegreeDiffrence(float angle1, float angle2)
    {
        angle1 %= 360;
        if (angle1 < 0)
            angle1 += 360;

        angle2 %= 360;
        if (angle2 < 0)
            angle2 += 360;


        if (angle1 == angle2)
            return 0;


        float approach1 = angle1 - angle2;
        if (angle1 < angle2)
            angle1 += 360;
        else
            angle2 += 360;

        float approach2 = angle1 - angle2;
        if (Mathf.Abs(approach1) < Mathf.Abs(approach2))
            return approach1;
        else
            return approach2;
    }

    public static float GetEaseFlow(float flow, NemoEaseMode ease)
    {
        switch (ease)
        {
            case NemoEaseMode.Linear: return flow;
            case NemoEaseMode.CubicIn: return flow * flow * flow;
            case NemoEaseMode.CubicOut: return (flow - 1) * (flow - 1) * (flow - 1) + 1;
            case NemoEaseMode.CubicInOut: return ((flow * 2 < 1) ? flow * flow * flow * 4.0f : ((flow - 1) * (flow - 1) * (flow - 1) * 8 + 1) / 2.0f + 0.5f);
        }
        return 0;
    }

    public enum NemoEaseMode
    {
        Linear,
        CubicIn,
        CubicOut,
        CubicInOut
    }
}
