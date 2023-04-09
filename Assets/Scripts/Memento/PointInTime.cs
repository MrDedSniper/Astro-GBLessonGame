using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PointInTime
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Velocity;
    public PointInTime (Vector3 position, Quaternion rotation, Vector3
        velocity)
    {
        Position = position;
        Rotation = rotation;
        Velocity = velocity;
    }
}