using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenetutorial : MonoBehaviour
{
    //public GameObject Dialog;
    //public GameObject DialogManage;
    public GameObject Tutorial;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Tutorial.SetActive(true);
            Destroy(gameObject);
        }
    }
}
