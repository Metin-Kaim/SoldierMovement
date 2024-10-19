using Scripts.Controllers;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerMovementController playerMovementController) : base(playerMovementController)
    {
    }

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Idle State");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.playerManager.isJumping)
        {
            Debug.LogWarning("isJumps");
            player.SwitchState(player.JumpState);
        }
        if (player.playerManager.isWalking)
        {
            player.SwitchState(player.WalkState);
        }

        if (player.playerManager.isAiming)
        {
            player.SwitchState(player.AimState);
        }
    }

    public override void ExitState(PlayerStateManager player)
    {

    }
}
