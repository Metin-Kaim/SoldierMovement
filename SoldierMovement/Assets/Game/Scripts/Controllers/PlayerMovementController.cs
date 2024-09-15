using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private const float Gravity = -9.81f;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravityForce = 4;

    private PlayerMovement _playerMovement;
    private Vector3 _velocity;
    private bool _isGrounded;
    
    private void Awake()
    {
        _playerMovement = new PlayerMovement();
        _playerMovement.Player.Movement.Enable();
        _playerMovement.Player.Rotate.Enable();
        _playerMovement.Player.Jump.Enable();
        _playerMovement.Player.Jump.started += Jump_started;
    }

    private void Update()
    {
        // Yerde olup olmadýðýný kontrol et
        _isGrounded = characterController.isGrounded;

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; // Yerdeyken hafif bir kuvvet uygulanýyor
        }

        // Hareket girdisini al
        Vector2 targetPos = _playerMovement.Player.Movement.ReadValue<Vector2>();
        Vector2 targetRot = _playerMovement.Player.Rotate.ReadValue<Vector2>();
        Vector3 move = new(targetPos.x, 0, targetPos.y);

        characterController.Move(speed * Time.deltaTime * move);
        transform.Rotate(mouseSensitivity * Time.deltaTime * new Vector3(0, targetRot.x, 0));

        // Yer çekimi uygula
        _velocity.y += Gravity * Time.deltaTime * gravityForce;
        characterController.Move(_velocity * Time.deltaTime);
    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        if (_isGrounded)
        {
            // Zýplama kuvveti uygula
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }
    }
}
