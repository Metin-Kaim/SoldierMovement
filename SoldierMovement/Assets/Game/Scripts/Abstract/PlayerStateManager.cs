using Assets.Game.Scripts.Managers;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState _currentState;

    public PlayerBaseState IdleState { get; private set; }
    public PlayerBaseState AimState { get; private set; }
    public PlayerBaseState WalkState { get; private set; }
    public PlayerBaseState JumpState { get; private set; }

    public PlayerManager playerManager;

    private void Awake()
    {
        IdleState = new PlayerIdleState(playerManager.playerMovementController);
        AimState = new PlayerAimState(playerManager.playerMovementController);
        WalkState = new PlayerWalkState(playerManager.playerMovementController);
        JumpState = new PlayerJumpState(playerManager.playerMovementController);
    }

    private void Start()
    {
        _currentState = IdleState;
        _currentState.EnterState(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }
}
