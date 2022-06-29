using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyActor : FightableActor
{

    [SerializeField]
    protected CircleCollider2D aggressionCollider;

    [SerializeField]
    protected float aggressionRadius = 1f;

    new protected void StateAwareStart()
    {
        base.StateAwareStart();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        aggressionRadius = sr.sprite.bounds.extents.y * 10;
        CreateCollider2D();
    }

    //may be handled on the editor
    void CreateCollider2D()
    {
        
        aggressionCollider = gameObject.AddComponent<CircleCollider2D>();
        aggressionCollider.isTrigger = true;
        aggressionCollider.radius = aggressionRadius;
    }

    private void OnCollisionEnter(Collision other) {
        //TODO: doesn't work
    }
} 
