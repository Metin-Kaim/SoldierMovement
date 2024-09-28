using Assets.Game.Scripts.Signals;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            CoreGameSignals.Instance.onSetMouseSensitivity.Invoke(mouseSensitivity);
        }

    }
}