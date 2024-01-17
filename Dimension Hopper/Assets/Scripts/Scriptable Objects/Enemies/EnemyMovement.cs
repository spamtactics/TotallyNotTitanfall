using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;  // Drag and drop the player GameObject onto this field in the Inspector
    public float moveSpeed = 5f;  // Adjust the movement speed as needed

    void Update()
    {
        if (player != null)
        {
            // Get the direction from the enemy to the player
            Vector3 direction = player.position - transform.position;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Calculate the movement amount based on the direction and speed
            Vector3 movement = direction * moveSpeed * Time.deltaTime;

            // Move the enemy towards the player
            transform.Translate(movement);
        }
        else
        {
            Debug.LogWarning("Player reference is missing. Please assign the player GameObject in the Inspector.");
        }
    }
}
