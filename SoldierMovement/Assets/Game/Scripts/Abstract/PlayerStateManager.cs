using Assets.Game.Scripts.Managers;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerIdleState idleState = new();
    public PlayerAimState aimState = new();

    public PlayerManager playerManager;

    private void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
