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
            // Yerde olup olmad���n� kontrol et
            _isGrounded = characterController.isGrounded;

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f; // Yerdeyken hafif bir kuvvet uygulan�yor
            }

            AllInputs allInputs = InputSignals.Instance.onGetAllInputs.Invoke();

            // Kameran�n y�n�n� al
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;

            // Y eksenini s�f�rla ��nk� yukar�/a�a�� hareket istemiyoruz
            cameraForward.y = 0;
            cameraRight.y = 0;

            cameraForward.Normalize();
            cameraRight.Normalize();

            // Hareket girdisini kameran�n y�n�ne g�re ayarla
            Vector3 move = (cameraForward * allInputs.moveValue.y + cameraRight * allInputs.moveValue.x);

            // E�er iki eksende de hareket varsa, vekt�r� normalize et
            if (move.magnitude > 1f)
            {
                move = move.normalized;
            }

            characterController.Move(speed * Time.deltaTime * move);


            // Mouse ile karakteri d�nd�r
            transform.Rotate(mouseSensitivity * Time.deltaTime * new Vector3(0, allInputs.rotateValue.x, 0));

            // Yer �ekimi uygula
            _velocity.y += GRAVITY * Time.deltaTime * gravityForce;
            characterController.Move(_velocity * Time.deltaTime);
        }


        public void OnJumpStarted()
        {
            if (_isGrounded)
            {
                // Z�plama kuvveti uygula
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY);
            }
        }
    }
}