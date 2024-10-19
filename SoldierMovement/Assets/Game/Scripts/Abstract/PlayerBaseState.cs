using Scripts.Controllers;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerMovementController playerMovementController;

    protected PlayerBaseState(PlayerMovementController playerMovementController)
    {
        this.playerMovementController = playerMovementController;
    }

    public abstract void EnterState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void ExitState(PlayerStateManager player);
}
