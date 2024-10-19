using Scripts.Controllers;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerMovementController playerMovementController) : base(playerMovementController)
    {
    }

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Walk State");
        player.playerManager.SetWalking(true); //true
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //if (playerMovementController.IsGrounded)
        playerMovementController.HandleMovement();

        if (player.playerManager.isJumping)
        {
            player.SwitchState(player.JumpState);
        }
        else if (player.playerManager.isAiming)
        {
            player.SwitchState(player.AimState);
        }
        else if (!player.playerManager.isWalking)
        {
            //player.playerManager.SetAiming();
            player.SwitchState(player.IdleState);
        }
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.playerManager.SetWalking(false); //false
    }
}
