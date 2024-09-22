using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Signals;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        private const float GRAVITY = -9.81f;

        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float mouseSensitivity = 3f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private float gravityForce = 4;

        private Vector3 _velocity;
        private bool _isGrounded;

        private void Update()
        {
            // Yerde olup olmadýðýný kontrol et
            _isGrounded = characterController.isGrounded;

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f; // Yerdeyken hafif bir kuvvet uygulanýyor
            }

            AllInputs allInputs = InputSignals.Instance.onGetAllInputs.Invoke();

            // Hareket girdisini al

            Vector3 move = new(allInputs.moveValue.x, 0, allInputs.moveValue.y);

            characterController.Move(speed * Time.deltaTime * move);
            transform.Rotate(mouseSensitivity * Time.deltaTime * new Vector3(0, allInputs.rotateValue.x, 0));

            // Yer çekimi uygula
            _velocity.y += GRAVITY * Time.deltaTime * gravityForce;
            characterController.Move(_velocity * Time.deltaTime);
        }

        private void Jump_started(InputAction.CallbackContext obj)
        {
            if (_isGrounded)
            {
                // Zýplama kuvveti uygula
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY);
            }
        }
    }
}