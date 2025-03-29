using UnityEngine;

public class Balcony : MonoBehaviour
{

    [SerializeField] private InteractableObjectS0 interactableObjectS0;
    [SerializeField] private Transform topPoint;
    private Chair chair;

    private void Start()
    {
        chair = FindObjectOfType<Chair>(); // Ensure it's assigned properly
    }
    public void Interact()
    {
        Debug.Log("Interact!");
        Transform interactableObjectTransform = Instantiate(interactableObjectS0.prefab, topPoint);
        interactableObjectTransform.localPosition = Vector3.zero;

        Debug.Log(interactableObjectTransform.GetComponent<InteractableObject>().GetInteractableObjectS0().objectName);

    }

}
