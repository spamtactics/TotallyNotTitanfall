using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public Transform player;  // Drag and drop the player GameObject onto this field in the Inspector

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Get the NavMeshAgent component attached to the enemy GameObject
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on the enemy GameObject.");
        }
    }

    void Update()
    {
        if (player != null && navMeshAgent != null)
        {
            // Set the destination for the NavMeshAgent to move towards the player
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            Debug.LogWarning("Player reference or NavMeshAgent is missing. Please assign the player GameObject and ensure a NavMeshAgent is attached to the enemy GameObject in the Inspector.");
        }
    }
}
