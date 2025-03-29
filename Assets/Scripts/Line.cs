using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private Transform carryPoint;
    [SerializeField] private InteractableObjectSO interactableObjectSO;

    private Transform interactObjectTransform; // Reference to the spawned object

    [SerializeField] private Transform spawnPoint;
    
    public bool HasPerson = false;

    public void Interact()
    {
        if (interactObjectTransform == null)  // Check if the object was destroyed already
        {
            interactObjectTransform = Instantiate(interactableObjectSO.prefab, carryPoint);
            interactObjectTransform.localPosition = Vector3.zero;
        }
    }

    public void DestroyInteractableObject()
    {
        if (interactObjectTransform != null)
        {
            Destroy(interactObjectTransform.gameObject);
            interactObjectTransform = null;
        }
    }

    // Corrected this method: it should return true if an object exists, false if it doesn't.
    public bool HasSpawnedObject()
    {
        return interactObjectTransform != null;  // Return true if there is a spawned object
    }
}
