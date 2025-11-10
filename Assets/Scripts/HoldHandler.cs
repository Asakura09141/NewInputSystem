using UnityEngine;
using UnityEngine.InputSystem;

public class HoldHandler : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.UI.HoldClick.performed += OnHoldClick;
    }

    private void OnEnable() =>
        _playerInput.Enable();

    private void OnDisable() =>
        _playerInput.Disable();

    private void OnDestroy() =>
        _playerInput.UI.HoldClick.performed -= OnHoldClick;

    public void OnHoldClick(InputAction.CallbackContext context) =>
        Debug.Log("Зажатая кнопка");
}