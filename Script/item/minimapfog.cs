using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapfog : MonoBehaviour
{
    private bool beenThere = false;
    public float shift;
    private SpriteRenderer Fog_W;
    public GameObject fog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            fog.gameObject.SetActive(false);

        }
    }

    
}
