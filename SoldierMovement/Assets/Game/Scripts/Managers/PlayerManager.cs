using Assets.Game.Scripts.Signals;
using Scripts.Controllers;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public PlayerMovementController playerMovementController;

        public bool isAiming;
        public Animator playerAnimator;
        public bool isWalking;
        public bool isJumping;

        private void OnEnable()
        {
            PlayerSignals.Instance.onJumpStarted += (x) => isJumping = x;
            CoreGameSignals.Instance.onSetMouseSensitivity += playerMovementController.UpdateMouseSens;
            PlayerSignals.Instance.onAiming += (isAiming) => this.isAiming = isAiming;
            PlayerSignals.Instance.onWalking += (isWalking) => this.isWalking = isWalking;
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.onJumpStarted -= (x) => isJumping = x;
            CoreGameSignals.Instance.onSetMouseSensitivity -= playerMovementController.UpdateMouseSens;
            PlayerSignals.Instance.onAiming -= (isAiming) => this.isAiming = isAiming;
        }
        public void SetAiming(bool isAiming)
        {
            print("isAiming: " + isAiming);
            playerAnimator.SetBool("aim", isAiming);
            //this.isAiming = isAiming;
        }

        public void SetWalking(bool isWalking)
        {
            playerAnimator.SetBool("walk", isWalking);
            //this.isWalking = isWalking;
        }

        public void SetJumping()
        {
            playerAnimator.SetTrigger("Jump");
        }
    }
}