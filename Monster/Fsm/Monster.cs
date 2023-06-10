using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private enum MonsterStateEnum
    {
        IDLE,
        CHASE,
        ATTACK,
        DEATH
    }
    private MonsterStateEnum _state;

    private void Start()
    {
        _state = MonsterStateEnum.IDLE;
    }

    private void Update()
    {
        switch (_state)
        {
            case MonsterStateEnum.IDLE:
                break;
            case MonsterStateEnum.CHASE:
                break;
            case MonsterStateEnum.ATTACK:
                break;
            case MonsterStateEnum.DEATH:
                break;
            default:
                break;
        }
    }
}