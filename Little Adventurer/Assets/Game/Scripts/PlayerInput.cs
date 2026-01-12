using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput;
    public float VerticalInput;
    public bool MouseButtonDown;
    public bool SpaceKeyDown;
    public bool ESCKeyDown;

    private InputSystem_Actions inputActions;
    private Vector2 moveInput;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.UI.Enable(); // この行を追加
        
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Attack.started += OnAttack;
        inputActions.Player.Jump.started += OnSlide;
        inputActions.UI.Pause.started += OnPause;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Attack.started -= OnAttack;
        inputActions.Player.Jump.started -= OnSlide;
        inputActions.UI.Pause.started -= OnPause;
        inputActions.Player.Disable();
        inputActions.UI.Disable(); // この行を追加

        // 移動入力はリセットしない - スライド後も移動を継続するため
        // HorizontalInput = 0;
        // VerticalInput = 0;

        // アクション入力のみクリア
        MouseButtonDown = false;
        SpaceKeyDown = false;
        ESCKeyDown = false;
    }

    private void OnDestroy()
    {
        inputActions?.Dispose();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        HorizontalInput = moveInput.x;
        VerticalInput = moveInput.y;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.name + " action triggered");

        if (Time.timeScale != 0)
        {
            MouseButtonDown = true;
        }
    }

    private void OnSlide(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.name + " action triggered");

        if (Time.timeScale != 0)
        {
            SpaceKeyDown = true;
        }
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.name + " action triggered");
        ESCKeyDown = true; // Time.timeScaleの条件を削除
    }

    public void ClearCache()
    {
        // HorizontalInput = 0;
        // VerticalInput = 0;
        MouseButtonDown = false;
        SpaceKeyDown = false;
        ESCKeyDown = false;
    }
}
