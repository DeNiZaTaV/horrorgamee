using UnityEngine;

public class canavass4 : MonoBehaviour
{
    public GameObject canvas; // Reference to your Canvas GameObject
    public GameObject targetObject; // Reference to the specific GameObject you want to click

    private AudioSource[] audioSources; // Array to hold multiple AudioSources
    private int currentAudioIndex = 0; // Index of the currently playing audio source

    private void Start()
    {
        // Initially, set the canvas to be inactive
        canvas.SetActive(false);

        // Get all the AudioSource components attached to the Canvas GameObject
        audioSources = canvas.GetComponents<AudioSource>();

        // Stop all audio sources initially
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray intersects with the targetObject
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == targetObject)
            {
                // Open the canvas if the targetObject is clicked
                canvas.SetActive(true);

                // Stop the previously playing audio source
                audioSources[currentAudioIndex].Stop();

                // Play the next audio source and update the current index
                currentAudioIndex = (currentAudioIndex + 1) % audioSources.Length;
                audioSources[currentAudioIndex].Play();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            // Close the canvas when right-clicked
            canvas.SetActive(false);

            // Stop the currently playing audio source
            audioSources[currentAudioIndex].Stop();
        }
    }
}