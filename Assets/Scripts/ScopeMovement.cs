using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeMovement : MonoBehaviour
{
	[SerializeField] private FirstMinigameController minigameController;
	
	[SerializeField] private float minX = -2.58f;
	[SerializeField] private float maxX = 1.65f;
	[SerializeField] private float minY = -3f;
	[SerializeField] private float maxY = 3f;
	public Transform target;
	public Rigidbody rb;
	public float force;
	private Vector3 randomPoint;
	private Vector3 spawnPoint;
	private float maxDistance;
	private bool gameOver = false;



	private void Start()
    {
        // Initialize Rigidbody
        rb = GetComponent<Rigidbody>();
		spawnPoint = transform.position;
        maxDistance = Mathf.Max(maxX, maxY);

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

    private void Update()
    {
		float distance = Vector3.Distance(transform.position, spawnPoint);

		if(distance < maxDistance)
		{
			// Check key input and apply force when key is pressed
			if (Input.GetKeyDown(KeyCode.W))
			{
				// Apply upward force (along Y axis using local up direction)
				Vector3 upwardForce = transform.up * 5f;  // Apply force upwards in the object's local space
				rb.AddForce(upwardForce, ForceMode.Impulse);  // Use Impulse to apply immediate force
				Debug.Log($"Upward Force Applied: {upwardForce}");
			}
			else if (Input.GetKeyDown(KeyCode.A))
			{
				// Apply leftward force (along X axis using local left direction)
				Vector3 leftwardForce = -transform.right * 5f;  // Apply force left in the object's local space
				rb.AddForce(leftwardForce, ForceMode.Impulse);  // Use Impulse to apply immediate force
				Debug.Log($"Leftward Force Applied: {leftwardForce}");
			}
			else if (Input.GetKeyDown(KeyCode.S))
			{
				// Apply downward force (along Y axis using local down direction)
				Vector3 downwardForce = -transform.up * 5f;  // Apply force downwards in the object's local space
				rb.AddForce(downwardForce, ForceMode.Impulse);  // Use Impulse to apply immediate force
				Debug.Log($"Downward Force Applied: {downwardForce}");
			}
			else if (Input.GetKeyDown(KeyCode.D))
			{
				// Apply rightward force (along X axis using local right direction)
				Vector3 rightwardForce = transform.right * 5f;  // Apply force right in the object's local space
				rb.AddForce(rightwardForce, ForceMode.Impulse);  // Use Impulse to apply immediate force
				Debug.Log($"Rightward Force Applied: {rightwardForce}");
			}
			else if (Input.GetKeyDown(KeyCode.Space))
			{
				// Force stop the object
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;

				// Apply force forward along the Z-axis
				Vector3 forwardForce = transform.forward * 40f;
				rb.AddForce(forwardForce, ForceMode.Impulse);
				Debug.Log($"Forward Force Applied: {forwardForce}");
			}
		}
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

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Plain") && gameOver == false)
		{
			minigameController.End(false);
		}
		else if (collision.gameObject.CompareTag("Arm") && gameOver == false)
		{
			minigameController.End(true);
		}
	}
}

