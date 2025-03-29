using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private Transform donerPrefab;
    [SerializeField] private Transform carryPoint;
    private Transform currentDoner; // Store the currently spawned object

    public void Interact()
    {
        Debug.Log("Interact");

        // If there is already a spawned doner, destroy it before instantiating a new one
        if (currentDoner != null)
        {
            Destroy(currentDoner.gameObject);
        }

        // Instantiate a new doner object
        currentDoner = Instantiate(donerPrefab, carryPoint);
        currentDoner.localPosition = Vector3.zero;
    }

    // Optionally, add a method to remove the doner from the scene if needed
    public void RemoveDoner()
    {
        if (currentDoner != null)
        {
            Destroy(currentDoner.gameObject);
        }
    }
}
