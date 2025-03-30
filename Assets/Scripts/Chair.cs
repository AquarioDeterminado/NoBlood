using UnityEngine;

public class Chair : BasePlatform
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private InteractableObjectSO interactableObjectSO;
    [SerializeField] private GameObject carryPoint;
    private Line line;  // Reference to the Line classT

    

    private InteractableObject interactableObject;

    [SerializeField] private GameController gameController;

    public override void Interact(Player2 player2)
    {
        Debug.Log("Override!");
        gameController.StartMinigame1();

        


    }

                


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

    }

  

    public void OnMinigameWin( )
    {
        if (interactableObject == null)
        {

           
             


        }
        else
        {
          
        }
    }

    public void OnMinigameLose()
    {
        Destroy(carryPoint.transform.GetChild(0).gameObject);
    }

}
