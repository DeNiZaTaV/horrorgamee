using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campos : MonoBehaviour
{
    public Transform cameraPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;

    }
}
