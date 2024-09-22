using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Signals;
using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputController inputController;

        private void OnEnable()
        {
            InputSignals.Instance.onGetAllInputs += inputController.OnGetAllInputs;
        }

        private void OnDisable()
        {
            InputSignals.Instance.onGetAllInputs -= inputController.OnGetAllInputs;
        }
    }
}