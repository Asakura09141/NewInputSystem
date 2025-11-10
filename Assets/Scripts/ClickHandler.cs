using UnityEngine;
using UnityEngine.InputSystem;

public class ClickHandler : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.UI.Click.performed += OnClick;
    }

    private void OnEnable() =>
        _playerInput.Enable();

    private void OnDisable() =>
        _playerInput.Disable();

    private void OnDestroy() =>
        _playerInput.UI.Click.performed -= OnClick;

    public void OnClick(InputAction.CallbackContext context) =>
        Debug.Log("Kлик");
}