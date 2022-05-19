using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startminigame : MonoBehaviour
{
    public GameObject MiniGame;
    public GameObject MiniCheck;
    public GameObject Thisone;
    public GameObject Minimap;
    public string CamMini;
    public static bool isMiniOn;
    public Animator camAnim;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camAnim.SetBool(CamMini, true);
            isMiniOn = true;
            MiniGame.SetActive(true);
            Minimap.SetActive(false);
        }
    }

    void Update()
    {
        if (MiniCheck.activeInHierarchy == true)
        {
            Invoke(nameof(StopMinigame), 3f);
        }
    }

    void StopMinigame()
    {
        isMiniOn = false;
        camAnim.SetBool(CamMini, false);
        //MiniCheck.SetActive(false);
        Minimap.SetActive(true);
        MiniGame.SetActive(false);
        Destroy(Thisone);
    }
}
