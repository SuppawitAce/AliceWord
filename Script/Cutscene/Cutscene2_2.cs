using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene2_2 : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject DialogManage;
    public GameObject Tutorial;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Tutorial.SetActive(false);
            Dialog.SetActive(true);
            DialogManage.SetActive(true);
            Destroy(gameObject);
        }
    }
}
