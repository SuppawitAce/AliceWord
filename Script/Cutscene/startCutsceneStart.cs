using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutsceneStart : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject DialogManage;
    public GameObject tutorial;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.tag == "Player")
        {
            tutorial.SetActive(false);
            Dialog.SetActive(true);
            DialogManage.SetActive(true);
            Destroy(gameObject);
        }
    }

}
