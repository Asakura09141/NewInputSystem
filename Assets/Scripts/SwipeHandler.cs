using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeHandler : MonoBehaviour
{
    [SerializeField] private float _minSwipeDistance = 50f;

    private PlayerInput _playerInput;
    private Vector2 _startPosition;
    private Vector2 _delta;
    private Mouse _mouse;
    private bool _isSwiping = false;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _mouse = Mouse.current;
        _playerInput.UI.Press.started += OnPressStarted;
        _playerInput.UI.Position.performed += OnPositionPerformed;
        _playerInput.UI.Press.canceled += OnPressCanceled;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnDestroy()
    {
        _playerInput.UI.Press.started -= OnPressStarted;
        _playerInput.UI.Position.performed -= OnPositionPerformed;
        _playerInput.UI.Press.canceled -= OnPressCanceled;
    }

    private void OnPressStarted(InputAction.CallbackContext context)
    {
        if (Mouse.current.leftButton.isPressed == false)
            return;

        _isSwiping = true;
        _startPosition = _mouse.position.ReadValue();
    }

    private void OnPositionPerformed(InputAction.CallbackContext context)
    {
        if (!_isSwiping)
            return;

        Vector2 currentPosition = _mouse.position.ReadValue();
        _delta = currentPosition - _startPosition;

        if (_delta.sqrMagnitude < _minSwipeDistance)
            return;

        _startPosition = currentPosition;
    }

    private void OnPressCanceled(InputAction.CallbackContext context)
    {
        _isSwiping = false;
        Debug.Log(_delta.x > 0 ? "Swipe: Right" : "Swipe: Left");
    }
}
