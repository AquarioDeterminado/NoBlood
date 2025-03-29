using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private InteractableObjectS0 interactableObjectS0;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Chair secondChair;
    [SerializeField] private bool testing;
    private Line line;
    public bool hasBlood = false;

    private InteractableObject interactableObject;


    private void Start()
    {
        line = FindObjectOfType<Line>(); // Ensure it's assigned properly
    }

    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T))
        {
            if (interactableObject != null) {
                interactableObject.SetChair(secondChair);
                Debug.Log(interactableObject.GetChair());
            }
        }
    }
    public void Interact()
    {
       
        
            if (interactableObject == null)
            {
            if (line.HasPerson == true)
            {
                Debug.Log("Interact!");
                Transform interactableObjectTransform = Instantiate(interactableObjectS0.prefab, grabPoint);
                interactableObjectTransform.localPosition = Vector3.zero;


                Debug.Log(interactableObjectTransform.GetComponent<InteractableObject>().GetInteractableObjectS0().objectName);

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
       

    
}
