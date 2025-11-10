using UnityEngine;
using UnityEngine.InputSystem;

public class DoubleClickHandler : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.UI.DoubleClick.performed += OnDoubleClick;
    }

    private void OnEnable() =>
        _playerInput.Enable();

    private void OnDisable() =>
        _playerInput.Disable();

    private void OnDestroy() =>
        _playerInput.UI.DoubleClick.performed -= OnDoubleClick;

    public void OnDoubleClick(InputAction.CallbackContext context) =>
        Debug.Log("Дабл клик");
}