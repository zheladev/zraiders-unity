using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class RaiderActor : FightableActor
{
    new protected void StateAwareStart()
    {
        base.StateAwareStart();
    }
}
