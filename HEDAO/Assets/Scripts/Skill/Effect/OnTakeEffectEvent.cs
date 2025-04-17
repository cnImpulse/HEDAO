using System;
using Cfg.Battle;

public class OnTakeEffectEvent
{
    public IEffectTarget Caser;
    public IEffectTarget Target;
    public int Damage;
    public bool IsMiss = false;
}

