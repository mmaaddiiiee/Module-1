
using UnityEngine;
//help from chatgpt to have 2 separte triggers for attack range adn follow range

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5f; // Movement speed of the enemy
    public float followRange = 10f; // Range at which the enemy will start following the player
    public float attackRange = 3f; // Range at which the enemy will attack the player
    public int damageAmount = 50; // Amount of damage done to the player

    private bool isFollowingPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowingPlayer = false;
        }
    }

    private void Update()
    {
        if (isFollowingPlayer && player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
            else if (distanceToPlayer <= followRange)
            {
                MoveTowardsPlayer();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        // Move towards the player
        transform.LookAt(player);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        // Apply damage to the player
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
