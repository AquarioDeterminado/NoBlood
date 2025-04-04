using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player2 : MonoBehaviour, IInterectableObjectParent
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInput2 gameInput2;

    private InteractableObject interactableObject;
    [SerializeField] private Transform grabPoint;

   



    private Vector3 lastInteractDir;


    private void Start()
    {
        gameInput2.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput2.GetMovementVectorNormalized2();


        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 4f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance))
        {

             if(raycastHit.transform.TryGetComponent(out BasePlatform basePlatform))
            {
                Debug.Log("Interact"!);
                basePlatform.Interact(this); 
            }
            if (raycastHit.transform.TryGetComponent(out Line line))
            {
                line.Interact();
            }

        }
    }
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }


    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput2.GetMovementVectorNormalized2();


        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance))
        {
            if (raycastHit.transform.TryGetComponent(out Line line))
            {
            }
            if (raycastHit.transform.TryGetComponent(out Counter counter))
            {
            }

        }

    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput2.GetMovementVectorNormalized2();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = Time.deltaTime * moveSpeed;
        float playerRadius = 0.3f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {

                }

            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }



        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }

    public Transform GetInteractableObjectFollowTransform()
    {
        return grabPoint;
    }

    public void SetInteractableObject(InteractableObject interactableObject)
    {
        this.interactableObject = interactableObject;
    }

    public InteractableObject GetInteractableObject()
    {
        return interactableObject;

    }

    public void ClearInteractableObject()
    {
        interactableObject = null;
    }

    public bool HasInteractableObject()
    {
        return interactableObject != null;
    }
}