using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 1; // Adjust enemy health as needed.

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Destroy the enemy when its health reaches or goes below zero.
            Destroy(gameObject);
        }
    }
}