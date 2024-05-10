using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Unity Inspector.
    public float bulletSpeed = 10f; // Adjust the speed of the bullets as needed.
    private Camera mainCamera; // Reference to the main camera.

    void Start()
    {
        // Find and store a reference to the main camera.
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Calculate the shooting direction based on the camera's forward vector.
            Vector3 cameraForward = mainCamera.transform.forward;

            // Instantiate a bullet at the player's position.
            Vector3 playerPosition = transform.position;
            GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.identity);

            // Apply velocity to the bullet in the camera's forward direction.
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = cameraForward * bulletSpeed;
        }
    }
}