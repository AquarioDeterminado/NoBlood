using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private InteractableObjectSO interactableObjectSO;

    private IInterectableObjectParent interactableObjectParent;
    public InteractableObjectSO GetInteractableObjectSO() {
    return interactableObjectSO;
    }

    public void SetInteractableObjectParent(IInterectableObjectParent interactableObjectParent) {
        if (this.interactableObjectParent != null) { 
            this.interactableObjectParent.ClearInteractableObject();
        
        }
        this.interactableObjectParent = interactableObjectParent;

        if (interactableObjectParent.HasInteractableObject())
        {
            Debug.LogError("IInteractableObjectParent already has a object");
        }
        interactableObjectParent.SetInteractableObject(this);

        transform.parent = interactableObjectParent.GetInteractableObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IInterectableObjectParent GetInteractableObjectParent() 
    { 
        return interactableObjectParent; 
    }

    
    

    
}
