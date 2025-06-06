using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput2 : MonoBehaviour
{
    private PlayerInputAction2 playerInputActions2;
    public event EventHandler OnInteractAction;

    private void Awake()
    {
        playerInputActions2 = new PlayerInputAction2();
        playerInputActions2.Player2.Enable();

        playerInputActions2.Player2.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty); // Safe invocation
    }

    public Vector2 GetMovementVectorNormalized2()
    {
        Vector2 inputVector = playerInputActions2.Player2.Move.ReadValue<Vector2>();
        return inputVector.normalized; // Simplified
    }

    private void OnDisable()
    {
        playerInputActions2.Player2.Disable(); // Proper cleanup
    }
}
