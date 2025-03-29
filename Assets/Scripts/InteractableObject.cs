using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private InteractableObjectS0 interactableObjectS0;

    private Chair chair;
    public InteractableObjectS0 GetInteractableObjectS0() {
    return interactableObjectS0;
    }

    public void SetChair(Chair chair) { }

    public Chair GetChair() { return chair; }

    
    

    
}
