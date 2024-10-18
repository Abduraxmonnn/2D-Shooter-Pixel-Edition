using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    public GameObject smallerPlayerPrefab; // Reference to the smaller Player prefab
    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Print a message when something enters the trigger
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Player")) // Check if the collided object is tagged as Player
        {
            Debug.Log("Original player touched the image!");

            // Inside your PlayerHelper or wherever you're instantiating the smaller player
            if (smallerPlayerPrefab != null)
            {
                Vector3 spawnPosition = other.transform.position; // You can adjust this if needed
                GameObject smallerPlayer = Instantiate(smallerPlayerPrefab, spawnPosition, Quaternion.identity);

                // Get the SmallerController component and set the original player reference
                SmallerController smallerController = smallerPlayer.GetComponent<SmallerController>();
                if (smallerController != null)
                {
                    Controller originalController = other.GetComponent<Controller>(); // Get the Controller component
                    smallerController.originalPlayer = originalController; // Set the reference to the original Controller
                    Debug.Log("Smaller player instantiated and linked to original player!");
                }

                // Particle effect
                if (pickupEffect != null)
                {
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);
                    Debug.Log("Particle effect instantiated!");
                }

                // Destroy this object if needed (optional)
                Destroy(gameObject);
                Debug.Log("Image destroyed after collision.");
            }
            else
            {
                Debug.LogError("Smaller player prefab is not assigned!");
            }
        }
        else
        {
            Debug.Log("The collided object is not tagged as Player.");
        }
    }
}
