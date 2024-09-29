using Assets.Game.Scripts.Signals;
using Scripts.Controllers;
using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController playerMovementController;

        public bool isAiming;
        public Animator playerAnimator;

        private void OnEnable()
        {
            PlayerSignals.Instance.onJumpStarted += playerMovementController.OnJumpStarted;
            CoreGameSignals.Instance.onSetMouseSensitivity += playerMovementController.UpdateMouseSens;
            PlayerSignals.Instance.onAiming += (isAiming) => this.isAiming = isAiming;
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.onJumpStarted -= playerMovementController.OnJumpStarted;
            CoreGameSignals.Instance.onSetMouseSensitivity -= playerMovementController.UpdateMouseSens;
            PlayerSignals.Instance.onAiming -= (isAiming) => this.isAiming = isAiming;
        }
    }
}