using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeHandler : MonoBehaviour
{
    [SerializeField] private float minSwipeDistance = 50f;

    private PlayerInput _playerInput;
    private Vector2 _startPosition;
    private bool _isSwiping = false;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.UI.Swipe.started += OnSwipeStarted;
        _playerInput.UI.Swipe.performed += OnSwipePerformed;
        _playerInput.UI.Swipe.canceled += OnSwipeCanceled;
    }

    private void OnSwipeStarted(InputAction.CallbackContext context)
    {
        if (Mouse.current.leftButton.isPressed == false)
            return;

        _isSwiping = true;
        _startPosition = Mouse.current.position.ReadValue();
    }

    private void OnSwipePerformed(InputAction.CallbackContext context)
    {
        if (!_isSwiping || Mouse.current.leftButton.isPressed == false)
            return;

        Vector2 currentPosition = Mouse.current.position.ReadValue();
        Vector2 delta = currentPosition - _startPosition;

        if (delta.sqrMagnitude < minSwipeDistance)
            return;

        if (delta.x > 0)
        {

            Debug.Log("Swipe: Right");
        }
        else
        {
            Debug.Log("Swipe: Left");
        }
    }

    private void OnSwipeCanceled(InputAction.CallbackContext context)
    {
        _isSwiping = false;
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
        _playerInput.UI.Swipe.started -= OnSwipeStarted;
        _playerInput.UI.Swipe.performed -= OnSwipePerformed;
        _playerInput.UI.Swipe.canceled -= OnSwipeCanceled;
    }
}
