using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

public class ShipModifier
{
    protected Player _player;
    public ShipModifier Next;
    public ShipModifier(Player player)
    {
        _player = player;
    }
    public void Add(ShipModifier cm)
    {
        if (Next != null)
        {
            Next.Add(cm);
        }
        else
        {
            Next = cm;
        }
    }
    public virtual void Handle() => Next?.Handle();
    public void SetNext(ShipModifier next){
        Next = next;
    }
    public virtual void Apply(GameManager gameManager){
        Handle();
    }
}

internal sealed class AddSpeedModifier : ShipModifier
{
    private readonly int _speed;

    public AddSpeedModifier(Player player, int speed)
        : base(player)
    {
        _speed = speed;
    }

    public override void Handle()
    {
        _player.speed += _speed;
        base.Handle();
    }
}

internal sealed class AddShieldModifier : ShipModifier
{
    private readonly int _maxDefense;
    public AddShieldModifier(Player player, int maxDefense)
        : base(player)
    {
        _maxDefense = maxDefense;
    }
    public override void Handle()
    {
        _player.shieldStrength += _maxDefense;
        base.Handle();
    }
}
