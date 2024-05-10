using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text endText; // Reference to the end game text component.
    private int enemiesKilled = 0;
    private const int maxEnemiesToKill = 4; // Set the desired number of enemies to kill.

    void Start()
    {
        endText.gameObject.SetActive(false); // Hide the end game text initially.
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        // Check if the player has killed the required number of enemies.
        if (enemiesKilled >= maxEnemiesToKill)
        {
            // Display the end game text.
            endText.gameObject.SetActive(true);
            endText.text = "You Win!";
        }
    }
}