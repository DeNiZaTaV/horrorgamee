using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ReadNote : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject inv;

    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inReach;



    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        pickUpText.SetActive(false);

        inReach = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }




    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            noteUI.SetActive(true);
           
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }


    public void ExitButton()
    {

        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
      

    }
}