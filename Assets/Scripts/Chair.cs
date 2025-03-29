using UnityEngine;

public class Chair : BasePlatform
{
    [SerializeField] private InteractableObjectSO interactableObjectSO;
    private Line line;  // Reference to the Line class

    public override void Interact(Player2 player2);
    [SerializeField] private InteractableObjectS0 interactableObjectS0;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Chair secondChair;
    [SerializeField] private bool testing;
    [SerializeField] private GameObject carryPoint;
    private Line line;
    public bool hasBlood = false;

    private InteractableObject interactableObject;

    [SerializeField] private GameController gameController;

    private void Start()
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

    public void Interact()
    {
        gameController.StartMinigame1();
    }

    public void OnMinigameWin()
    {
        if (interactableObject == null)
        {
            if (line.HasPerson)
            {
                Transform interactableObjectTransform = Instantiate(interactableObjectS0.prefab, grabPoint);
                interactableObjectTransform.localPosition = Vector3.zero;

                interactableObject = interactableObjectTransform.GetComponent<InteractableObject>();
                interactableObject.SetChair(this);
                hasBlood = true;

                Destroy(line);
            }
        }
    }

    public void OnMinigameLose()
    {
        Destroy(carryPoint.transform.GetChild(0).gameObject);
    }

}
