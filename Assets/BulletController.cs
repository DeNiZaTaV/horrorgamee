using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 1; // Adjust bullet damage as needed.

    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collided with an enemy.
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            // Damage the enemy and destroy the bullet.
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}