using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator camAnim;
    //public Object Tutorwial;
    public Spawner spawner;
    //public Behaviour Rab;
    public GameObject Dialog;
    public GameObject tutorial;
    public GameObject DialogManage;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player")
        {
            spawner.SpawnObject();
            isCutsceneOn = true;
            Destroy(tutorial);
            camAnim.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 3f);
            Dialog.SetActive(true);
            DialogManage.SetActive(true);
        }
    }

    void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);
        Destroy(gameObject);

    }
}
