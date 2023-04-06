using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IAim 
{
    Transform BarrelPositionAim { get; }
    GameObject AimInstance { get; }
}
