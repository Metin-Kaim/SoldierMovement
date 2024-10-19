using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Signals;
using UnityEngine;

namespace Scripts.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        private const float GRAVITY = -9.81f;

        [Header("References")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform camPoint;
        [Header("Settings")]
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private float gravityForce = 4;
        [SerializeField] private float camMaxUpDegree;
        [SerializeField] private float camMaxDownDegree;

        private Vector3 _velocity;
        private bool _isGrounded;
        private Vector3 _camDirection;
        private float _mouseSensitivity;

        public bool IsGrounded => _isGrounded;

        private void Update()
        {
            #region Check Is Ground And Apply Fake Gravity
            // Yerde olup olmadýðýný kontrol et
            _isGrounded = characterController.isGrounded;

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f; // Yerdeyken hafif bir kuvvet uygulanýyor
            }
            #endregion

            #region Get All Inputs
            AllInputs allInputs = GetAllInputs();
            #endregion

            //HandleMovement(allInputs);
            #region Character X Axis Rotation
            // Mouse ile karakteri döndür
            transform.Rotate(_mouseSensitivity * Time.deltaTime * new Vector3(0, allInputs.rotateValue.x, 0));
            #endregion

            #region Camera Up/Down Rotation
            _camDirection -= _mouseSensitivity / 1.5f * Time.deltaTime * new Vector3(allInputs.rotateValue.y, 0, 0);
            _camDirection.x = Mathf.Clamp(_camDirection.x, -camMaxUpDegree, camMaxDownDegree);

            camPoint.localEulerAngles = _camDirection;
            #endregion

            //HandleJump();
            #region Aplly Gravity
            // Yer çekimi uygula
            _velocity.y += GRAVITY * Time.deltaTime * gravityForce;
            characterController.Move(_velocity * Time.deltaTime);
            #endregion
        }

        private static AllInputs GetAllInputs()
        {
            return InputSignals.Instance.onGetAllInputs.Invoke();
        }

        public void HandleMovement()
        {
            AllInputs allInputs = GetAllInputs();

            #region Character Movement By Camera Rotation
            // Kameranýn yönünü al
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;

            // Y eksenini sýfýrla çünkü yukarý/aþaðý hareket istemiyoruz
            cameraForward.y = 0;
            cameraRight.y = 0;

            cameraForward.Normalize();
            cameraRight.Normalize();

            // Hareket girdisini kameranýn yönüne göre ayarla
            Vector3 move = (cameraForward * allInputs.moveValue.y + cameraRight * allInputs.moveValue.x);

            // Eðer iki eksende de hareket varsa, vektörü normalize et
            if (move.magnitude > 1f)
            {
                move = move.normalized;
            }

            characterController.Move(speed * Time.deltaTime * move);
            #endregion
        }

        public void UpdateMouseSens(float mouseSens)
        {
            _mouseSensitivity = mouseSens;
        }

        public void HandleJump()
        {
            if (_isGrounded)
            {
                // Zýplama kuvveti uygula
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY);
            }
        }
    }
}