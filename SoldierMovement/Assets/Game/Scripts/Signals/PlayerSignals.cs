using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Game.Scripts.Signals
{
    public class PlayerSignals : MonoBehaviour
    {
        public static PlayerSignals Instance;

        public UnityAction onJumpStarted;
        public UnityAction<bool> onAiming;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
    }
}