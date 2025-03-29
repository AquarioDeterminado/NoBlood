using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balcony : MonoBehaviour
{
    [SerializeField] private Transform bloodPrefab;  // Reference to the blood prefab
    [SerializeField] private Transform dropPoint;    // Point where the blood should be dropped
    private Transform currentBlood; // To store the current blood object, if needed

    public void Interact()
    {
        Debug.Log("Interact with Balcony");

        // Check if there's already blood on the balcony and remove it
        if (currentBlood != null)
        {
            Destroy(currentBlood.gameObject); // Remove any existing blood object
        }

        // Instantiate the blood at the specified drop point (on the balcony)
        currentBlood = Instantiate(bloodPrefab, dropPoint.position, Quaternion.identity);
    }
}
