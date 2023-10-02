using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterControls playerInputs;
    private Transform playerTransform;
    private Vector2 moveDirection;

    [SerializeField] private float velocity;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();

        playerInputs = new CharacterControls();
        playerInputs.PlayerBehaviour.Move.started += OnMoveInputReceived;
        playerInputs.PlayerBehaviour.Move.performed += OnMoveInputReceived;
        playerInputs.PlayerBehaviour.Move.canceled += OnMoveInputReceived;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerTransform.Translate(new Vector2(moveDirection.x, moveDirection.y) * velocity * Time.deltaTime);
    }

    private void OnMoveInputReceived(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
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
