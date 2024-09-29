using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Idle State");
        player.playerManager.playerAnimator.SetBool("aim", false);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.playerManager.isAiming)
        {
            player.SwitchState(player.aimState);
        }
    }
}
