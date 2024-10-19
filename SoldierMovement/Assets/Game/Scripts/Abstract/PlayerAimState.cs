using Scripts.Controllers;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerAimState : PlayerBaseState
{
    public PlayerAimState(PlayerMovementController playerMovementController) : base(playerMovementController)
    {
    }

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Aim State");
        player.playerManager.SetAiming(true);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.playerManager.isJumping)
        {
            player.SwitchState(player.JumpState);
        }
        else if (!player.playerManager.isAiming)
        {
            if (player.playerManager.isWalking)
            {
                player.SwitchState(player.WalkState);
            }
            else
            {
                player.SwitchState(player.IdleState);
            }
        }
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.playerManager.SetAiming(false); //false
    }
}
