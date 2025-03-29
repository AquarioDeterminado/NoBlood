using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlatform : MonoBehaviour, IInterectableObjectParent
{


    [SerializeField] private Transform objectOnPoint;
    private InteractableObject interactableObject;

    public virtual void Interact(Player2 player2 )
    {

    }


    public Transform GetInteractableObjectFollowTransform()
    {
        return objectOnPoint;
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
