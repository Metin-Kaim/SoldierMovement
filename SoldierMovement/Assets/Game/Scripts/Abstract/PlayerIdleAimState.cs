using UnityEngine;

public class PlayerIdleAimState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Aim state");
        player.playerManager.playerAnimator.SetBool("aim", true);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (!player.playerManager.isAiming)
        {
            player.SwitchState(player.idleState);
        }
    }
}
