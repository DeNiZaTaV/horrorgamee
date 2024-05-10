using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Vector3 targetDestination;
    public bool isShot = false;

    private void Update()
    {
        if (!isShot)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetDestination, Time.deltaTime * 5f);

            if (Vector3.Distance(transform.position, targetDestination) < 0.1f)
            {
                isShot = true;
                gameObject.SetActive(false); // Disappear when reaching the destination
            }
        }
    }
}