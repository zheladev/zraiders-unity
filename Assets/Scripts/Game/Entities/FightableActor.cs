using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class FightableActor : StatefulActor
{
    //Action<type> for functions that take in parameters
    protected Dictionary<string, Action> stateUpdateActions;

    [SerializeField]
    protected FightableActor target;
    protected Rigidbody2D rigidBody;
    protected CircleCollider2D attackRadiusTriggerCollider;
    protected BoxCollider2D actorCollider;
    
    [SerializeField]
    protected float attackRadius = 0.2f;

    new protected void StateAwareStart()
    {
        base.StateAwareStart();

        //create rigid body for actor
        CreateRigidBody2D();
        CreateColliders2D();

        //load state actions into dictionary
        stateUpdateActions = new Dictionary<string, Action>() {
            {FightableActorStates.ATTACK, AttackUpdate},
            {FightableActorStates.DEAD, DeadUpdate},
            {FightableActorStates.DYING, DyingUpdate},
            {FightableActorStates.IDLE, IdleUpdate},
            {FightableActorStates.RESURRECT, ResurrectUpdate},
            {FightableActorStates.WALK, WalkUpdate},
        };
    }

    void CreateColliders2D()
    {
        //attack radius
        attackRadiusTriggerCollider = gameObject.AddComponent<CircleCollider2D>();
        attackRadiusTriggerCollider.isTrigger = true;
        attackRadiusTriggerCollider.radius = attackRadius;

        //self collider
        actorCollider = gameObject.AddComponent<BoxCollider2D>();
    }

    protected void StateAwareUpdate()
    {
        stateUpdateActions[state]();
    }

    void CreateRigidBody2D()
    {
        rigidBody = gameObject.AddComponent<Rigidbody2D>();
    }

    protected abstract void AttackUpdate();
    protected abstract void DeadUpdate();
    protected abstract void DyingUpdate();
    protected abstract void IdleUpdate();
    protected abstract void ResurrectUpdate();
    protected abstract void WalkUpdate();
}
