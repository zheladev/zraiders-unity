using System;
using System.Collections.Generic;
using System.Linq;
public static class FightableActorStates
{
    public static string IDLE = "Idle";
    public static string WALK = "Walk";
    public static string ATTACK = "Attack";
    public static string DYING = "Dying";
    public static string DEAD = "Dead";
    public static string RESURRECT = "Resurrect";

    public static List<string> POSSIBLE_STATES = new List<string>{
        IDLE, 
        WALK, 
        ATTACK, 
        DYING, 
        DEAD, 
        RESURRECT
    };
}
