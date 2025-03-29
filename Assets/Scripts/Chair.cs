using UnityEngine;

public class Chair : BasePlatform
{
    [SerializeField] private InteractableObjectSO interactableObjectSO;
    private Line line;  // Reference to the Line class

    public override void Interact(Player2 player2)
    {
        // Find the line in the scene (adjust according to how you manage the Line reference)
        line = FindObjectOfType<Line>(); // Or another way to reference the Line

        // Check if the spawned object in Line is destroyed
        if (line.HasSpawnedObject())
        {
            line.DestroyInteractableObject();
            Debug.Log("Cannot interact with chair until spawned object is destroyed.");
            return; // Exit if the object hasn't been destroyed
        }

        // If no spawned object exists (it was destroyed), interact with the chair
        Transform interactObjectTransform = Instantiate(interactableObjectSO.prefab);
        interactObjectTransform.GetComponent<InteractableObject>().SetInteractableObjectParent(player2);
    }
}
