using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private InteractableObjectS0 interactableObjectS0;
    [SerializeField] private Transform spawnPoint;
    
    [SerializeField] private GameController gameController; // []

    public bool HasPerson = false;

    private InteractableObject interactableObject;
    public void Interact()
    {
        if(interactableObject == null)
        {
            gameController.StartMinigame1();
        }
    }

    public void OnMinigame1Win()
    {
        Transform interactableObjectTransform = Instantiate(interactableObjectS0.prefab, spawnPoint);
        interactableObjectTransform.localPosition = Vector3.zero;
        interactableObject = interactableObjectTransform.GetComponent<InteractableObject>();
        HasPerson = true;
    }
}
