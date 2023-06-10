using UnityEngine;

public class Bot: Monster
{
    // TEST
    [SerializeField] public Vector3 position = new Vector3(10, 0, 0);
    [SerializeField] public int hp = 5;
    private Vector3 _playerPosition = new Vector3(0, 0, 0);
    private enum BotStateEnum
    {
        IDLE,
        CHASE,
        ATTACK,
        DEATH
    }

    private BotStateEnum _currentState;
    private FSM _fsm;

    private void Start()
    {
        transform.position = position;
        _currentState = BotStateEnum.IDLE;
        _fsm = new FSM(new IdleState(this));
    }

    private void Update()
    {
        switch (_currentState)
        {
            case BotStateEnum.IDLE:
                if (IsHpZero(this) == false)
                {
                    if (CanAttackPlayer(this))
                    {
                        ChangeState(BotStateEnum.ATTACK);
                    }
                    else if (CanSeePlayer(this))
                    {
                        ChangeState(BotStateEnum.CHASE);
                    }
                    // TEST
                    else
                    {
                        _playerPosition = new Vector3(_playerPosition.x + 1, 0, 0);
                    }
                }
                else
                {
                    ChangeState(BotStateEnum.DEATH);
                }
                break;
            case BotStateEnum.CHASE:
                if (IsHpZero(this) == false)
                {
                    if (CanAttackPlayer(this))
                    {
                        ChangeState(BotStateEnum.ATTACK);
                    }
                    else if (CanSeePlayer(this) == false)
                    {
                        ChangeState(BotStateEnum.IDLE);
                    }
                }
                else
                {
                    ChangeState(BotStateEnum.DEATH);
                }
                break;
            case BotStateEnum.ATTACK:
                if (IsHpZero(this) == false)
                {
                    if (CanAttackPlayer(this) == false)
                    {
                        if (CanSeePlayer(this))
                        {
                            ChangeState(BotStateEnum.CHASE);
                        }
                        else
                        {
                            ChangeState(BotStateEnum.IDLE);
                        }
                    }
                }
                else
                {
                    ChangeState(BotStateEnum.DEATH);
                }
                break;
            case BotStateEnum.DEATH:
                // TODO: DEATH 코드 구현
                break;
            default:
                break;
        }
        _fsm.UpdateState();
    }
    
    
    private void ChangeState(BotStateEnum nextState)
    {
        _currentState = nextState;
        switch (_currentState)
        {
            case BotStateEnum.IDLE:
                _fsm.ChangeState(new IdleState(this));
                break;
            case BotStateEnum.CHASE:
                _fsm.ChangeState(new ChaseState(this));
                break;
            case BotStateEnum.ATTACK:
                _fsm.ChangeState(new AttackState(this));
                break;
            case BotStateEnum.DEATH:
                _fsm.ChangeState(new DeathState(this));
                break;
            default:
                break;
        }
    }

    
    private bool CanSeePlayer(Bot bot)
    {
        Debug.Log("[CanSeePlayer] Distance: " + Vector3.Distance(bot.transform.position, _playerPosition));
        if (Vector3.Distance(bot.transform.position, _playerPosition) < 10f)
        {
            return true;
        }

        return false;
    } 
    
    private bool CanAttackPlayer(Bot bot)
    {
        Debug.Log("[CanAttackPlayer] Distance: " + Vector3.Distance(bot.transform.position, _playerPosition));
        if (Vector3.Distance(bot.transform.position, _playerPosition) < 5f)
        {
            return true;
        }

        return false;
    }

    private bool IsHpZero(Bot bot)
    {
        Debug.Log("[IsHpZero] hp: " + bot.hp);
        if (bot.hp <= 0)
        {
            return true;
        }

        return false;
    }
}