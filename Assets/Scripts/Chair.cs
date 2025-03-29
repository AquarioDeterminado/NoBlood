using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private InteractableObjectS0 interactableObjectS0;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Chair secondChair;
    [SerializeField] private bool testing;
    private Line line;

    private InteractableObject interactableObject;

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
        if (line.HasPerson == true)
        {
            if (interactableObject == null)
            {
                Debug.Log("Interact!");
                Transform interactableObjectTransform = Instantiate(interactableObjectS0.prefab, grabPoint);
                interactableObjectTransform.localPosition = Vector3.zero;

                Debug.Log(interactableObjectTransform.GetComponent<InteractableObject>().GetInteractableObjectS0().objectName);

                interactableObject = interactableObjectTransform.GetComponent<InteractableObject>();
                interactableObject.SetChair(this);
            }
            else
            {
                Debug.Log(interactableObject.GetChair());
            }

        }
       

    }
}
