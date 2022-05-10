using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene2_4 : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject DialogManage;
    public GameObject Barrier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Barrier.SetActive(false);
            Dialog.SetActive(true);
            DialogManage.SetActive(true);
            Destroy(gameObject);
        }
    }
}
