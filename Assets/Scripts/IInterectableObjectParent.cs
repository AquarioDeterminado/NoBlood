using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterectableObjectParent 
{
    public Transform GetInteractableObjectFollowTransform();


    public void SetInteractableObject(InteractableObject interactableObject);
    
    public InteractableObject GetInteractableObject();


    public void ClearInteractableObject();


    public bool HasInteractableObject();
    
}
