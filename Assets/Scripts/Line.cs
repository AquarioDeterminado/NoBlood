using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private InteractableObjectS0 interactableObjectS0;
    [SerializeField] private Transform spawnPoint;

    private InteractableObject interactableObject;
    public void Interact()
    {
        if(interactableObject == null)
        {
            Transform interactableObjectTransform = Instantiate(this.interactableObjectS0.prefab, spawnPoint);
            interactableObjectTransform.localPosition = Vector3.zero;
            interactableObject = interactableObjectTransform.GetComponent<InteractableObject>();    
        }
        

    }
}
