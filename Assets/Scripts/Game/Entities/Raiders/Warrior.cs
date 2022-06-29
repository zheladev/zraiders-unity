using UnityEngine;

public class Warrior : RaiderActor
{
    void Start() {
        //parent start
        base.StateAwareStart();
        //class start
    }
    void Update() {
        StateAwareUpdate();

        if (Input.GetKey(KeyCode.W)) 
        {
            state = FightableActorStates.WALK;
        }

        if (Input.GetKey(KeyCode.S))
        {
            state = FightableActorStates.IDLE;
        }
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
