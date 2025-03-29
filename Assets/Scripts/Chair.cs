using UnityEngine;

public class Chair : MonoBehaviour
{
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
        line = FindObjectOfType<Line>(); // Ensure it's assigned properly
    }

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (interactableObject != null)
            {
                interactableObject.SetChair(secondChair);
                Debug.Log(interactableObject.GetChair());
            }
        }
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
        else
        {
            Debug.Log(interactableObject.GetChair());
        }
    }

    public void OnMinigameLose()
    {
        Destroy(carryPoint.transform.GetChild(0).gameObject);
    }

}
