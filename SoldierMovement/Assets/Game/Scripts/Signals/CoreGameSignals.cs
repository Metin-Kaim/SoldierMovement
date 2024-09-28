using UnityEngine;
using UnityEngine.Events;

namespace Assets.Game.Scripts.Signals
{
    public class CoreGameSignals : MonoBehaviour
    {
        public static CoreGameSignals Instance;

        public UnityAction<float> onSetMouseSensitivity = delegate { };

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
                return;
            }
            Instance = this;
        }
    }
}