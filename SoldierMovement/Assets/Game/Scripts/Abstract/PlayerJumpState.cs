using Scripts.Controllers;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerMovementController playerMovementController) : base(playerMovementController)
    {
    }

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Jump State");
        player.playerManager.SetJumping(); //true   
        playerMovementController.HandleJump();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (playerMovementController.IsGrounded && !player.playerManager.isJumping)
        {
            player.SwitchState(player.IdleState);
        }
    }

    public override void ExitState(PlayerStateManager player) { }
}
