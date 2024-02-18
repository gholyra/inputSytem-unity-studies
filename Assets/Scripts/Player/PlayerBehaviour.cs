using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private CharacterControls playerInputs;
    
    private Transform playerTransform;
    private Vector2 moveDirection;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float velocity;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerInputs = new CharacterControls();
        playerInputs.PlayerBehaviour.Move.started += OnMoveInputReceived;
        playerInputs.PlayerBehaviour.Move.performed += OnMoveInputReceived;
        playerInputs.PlayerBehaviour.Move.canceled += OnMoveInputReceived;
        
        playerInputs.PlayerBehaviour.Jump.started += OnJumpInputReceived;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (moveDirection.x != 0)
        {
            spriteRenderer.flipX = !(moveDirection.x > 0);
        }
        
        playerTransform.Translate(new Vector2(moveDirection.x, moveDirection.y) * velocity * Time.deltaTime);
    }

    private void HandleAnimation()
    {
        
    }

    private void OnMoveInputReceived(InputAction.CallbackContext context)
    {
        moveDirection.x = context.ReadValue<float>();
    }

    private void OnJumpInputReceived(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
        playerInputs.PlayerBehaviour.Move.started -= OnMoveInputReceived;
        playerInputs.PlayerBehaviour.Move.performed -= OnMoveInputReceived;
        playerInputs.PlayerBehaviour.Move.canceled -= OnMoveInputReceived;
    }

}
