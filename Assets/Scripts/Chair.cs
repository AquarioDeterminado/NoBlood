using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private Transform bloodPrefab;
    [SerializeField] private Transform grabPoint;
    private Line lineScript; // Reference to the Line script to remove the doner

    private void Start()
    {
        // Find the Line script in the scene (assuming the Line is attached to the same object or can be referenced in some way)
        lineScript = FindObjectOfType<Line>(); // Or reference it directly if needed
    }

    public void Interact()
    {
        Debug.Log("Interact");

        // Remove the doner (from the Line interaction) when interacting with the chair
        if (lineScript != null)
        {
            lineScript.RemoveDoner(); // Remove the doner from the scene
        }

        // Instantiate the bloodPrefab at the chair's grabPoint
        Transform bloodTransform = Instantiate(bloodPrefab, grabPoint);
        bloodTransform.localPosition = Vector3.zero;
    }
}
