using System;
using UnityEngine;
using UnityEngine.UIElements;

public class IdleState: MonsterBaseState
{
    private Bot _bot;

    public IdleState(Bot bot) : base(bot)
    {
        _bot = bot;
    }


    public override void OnStateStart()
    {
        Debug.Log("===== Start Idle =====");

    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateEnd()
    {
        Debug.Log("===== End Idle =====");
    }

}

public class ChaseState: MonsterBaseState
{
    private Bot _bot;

    public ChaseState(Bot bot) : base(bot)
    {
        _bot = bot;
    }


    public override void OnStateStart()
    {
        Debug.Log("===== Start Chase =====");   
    }

    public override void OnStateUpdate()
    {
        Debug.Log("===== In Chase =====");   
        // TEST
        _bot.transform.position = new Vector3(_bot.transform.position.x - 1, 0, 0);
    }

    public override void OnStateEnd()
    {
        Debug.Log("===== End Chase =====");
    }

}

public class AttackState: MonsterBaseState
{
    private Bot _bot;

    public AttackState(Bot bot) : base(bot)
    {
        _bot = bot;
    }


    public override void OnStateStart()
    {
        Debug.Log("===== Start Attack =====");
    }

    public override void OnStateUpdate()
    {
        Debug.Log("===== In Attack =====");
        // TEST
        _bot.hp -= 1;
    }

    public override void OnStateEnd()
    {
        Debug.Log("===== End Attack =====");
    }

}



public class DeathState: MonsterBaseState
{
    private Bot _bot;
    public DeathState(Bot bot) : base(bot)
    {
        _bot = bot;
    }


    public override void OnStateStart()
    {
        Debug.Log("===== Start Death =====");
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateEnd()
    {
        Debug.Log("===== End Death =====");
    }

}
