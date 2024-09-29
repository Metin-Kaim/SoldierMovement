using UnityEngine;

public class PlayerAimState : PlayerBaseState
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
