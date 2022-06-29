using System.Collections.Generic;
using UnityEngine;
using System;

public class StatefulActor : MonoBehaviour
{
    [SerializeField]
    string _state = FightableActorStates.IDLE;

    //backing field
    public string state
    {
        get => _state;
        set
        {
            if (!FightableActorStates.POSSIBLE_STATES.Contains(value))
            {
                throw new System.InvalidOperationException();
            }

            _state = value;
        }
    }

    protected void StateAwareStart() {
        
    }
}
