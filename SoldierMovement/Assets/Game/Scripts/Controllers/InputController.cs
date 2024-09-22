using Assets.Game.Scripts.Signals;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        public Vector2 targetPos;
        public Vector2 targetRot;

        private void Awake()
        {

            _playerMovement = new PlayerMovement();
            _playerMovement.Player.Movement.Enable();
            _playerMovement.Player.Rotate.Enable();
            _playerMovement.Player.Jump.Enable();
            //_playerMovement.Player.Jump.started += Jump_started;
        }

        private void OnEnable()
        {
            InputSignals.Instance.onGetAllInputs += OnGetAllInputs;
        }
        private void OnDisable()
        {
            InputSignals.Instance.onGetAllInputs -= OnGetAllInputs;
        }

        private void Update()
        {
            targetPos = _playerMovement.Player.Movement.ReadValue<Vector2>();
            targetRot = _playerMovement.Player.Rotate.ReadValue<Vector2>();
        }

        public AllInputs OnGetAllInputs()
        {

            return new AllInputs { moveValue = targetPos, rotateValue = targetRot };
        }
    }

    public class AllInputs
    {
        public Vector2 moveValue;
        public Vector2 rotateValue;
    }
}