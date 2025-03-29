using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput2 : MonoBehaviour
{
    private PlayerInputAction2 playerInputActions2;

    private void Awake()
    {
        playerInputActions2 = new PlayerInputAction2();
        playerInputActions2.Player2.Enable();
    }
    public Vector2 GetMovementVectorNormalized2()
    {
        Vector2 inputVector = playerInputActions2.Player2.Move.ReadValue<Vector2>();


        inputVector = inputVector.normalized;

        return inputVector;
    }
}
