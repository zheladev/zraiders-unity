using UnityEngine;

public abstract class EnemyActor : FightableActor
{

    [SerializeField]
    protected CircleCollider2D aggressionTriggerCollider;

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
        
        aggressionTriggerCollider = gameObject.AddComponent<CircleCollider2D>();
        aggressionTriggerCollider.isTrigger = true;
        aggressionTriggerCollider.radius = aggressionRadius;
    }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Collide");
    }
} 
