using UnityEngine;

public class Imp : EnemyActor
{
    void Start()
    {
        //parent start
        base.StateAwareStart();
        //class start
    }
    void Update()
    {
        StateAwareUpdate();
    }

    protected override void AttackUpdate()
    {
    }

    protected override void DeadUpdate()
    {
    }

    protected override void DyingUpdate()
    {
    }

    protected override void IdleUpdate()
    {
    }

    protected override void ResurrectUpdate()
    {
    }

    protected override void WalkUpdate()
    {
    }
}
