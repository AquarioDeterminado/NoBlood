using UnityEngine;

public class Balcony : MonoBehaviour
{

    [SerializeField] private InteractableObjectS0 interactableObjectS0;
    [SerializeField] private Transform topPoint;
    public void Interact()
    {
        Debug.Log("Interact!");
        Transform interactableObjectTransform = Instantiate(interactableObjectS0.prefab, topPoint);
        interactableObjectTransform.localPosition = Vector3.zero;

        Debug.Log(interactableObjectTransform.GetComponent<InteractableObject>().GetInteractableObjectS0().objectName);

    }

}
