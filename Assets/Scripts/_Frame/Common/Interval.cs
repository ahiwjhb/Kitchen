using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Interval
{
    public float leftEndPoint;

    public float rightEndPoint;

    public Interval(float leftEndPoint, float rightEndPoint)
    {
        this.leftEndPoint = leftEndPoint;
        this.rightEndPoint = rightEndPoint;
    }

    public bool IsWithinRange(float value)
    {
        return value >= leftEndPoint && value <= rightEndPoint;
    }

    public float Clamp(float value)
    {
        return Mathf.Clamp(value, leftEndPoint, rightEndPoint);
    }
}
