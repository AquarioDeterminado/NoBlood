using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armMovement : MonoBehaviour
{
	[SerializeField] private float minX = -2.58f;
	[SerializeField] private float maxX = 1.65f;
	[SerializeField] private float minY = -3f;
	[SerializeField] private float maxY = 3f;
	public Transform target;
	public Rigidbody rb;
	public float force;
	private Vector3 randomPoint;

    private void Start()
    {
        // Initialize Rigidbody
        rb = GetComponent<Rigidbody>();

        // Start the randomizer loop
        InvokeRepeating("GenerateRandomNumbers", 0f, 2f);
    }

    private void FixedUpdate()
    {
        // RigidBody
        Vector3 f = new Vector3(randomPoint.x - transform.position.x, randomPoint.y - transform.position.y, 0f);
        f = f.normalized;
        f = f * force;
        rb.AddForce(f);
    }

    void GenerateRandomNumbers()
    {
        // Generate random numbers within the specified range
        float randomX = Random.Range(target.position.x + minX, target.position.x + maxX);
		float randomY = Random.Range(target.position.y + minY, target.position.y + maxY);

		// Set the new target point
		randomPoint = new Vector3(randomX, randomY, transform.position.z);

        // Output the results (or use the numbers as needed)
        Debug.Log($"New Random Point: {randomPoint}");
    }
}
