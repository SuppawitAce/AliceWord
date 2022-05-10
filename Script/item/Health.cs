using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    private Animator anim;
    private bool dead;


    [Header("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numOfFlash;
    private SpriteRenderer spriteRend;



    public float currentHealth{ get; private set; }

    void Start()
    {

    }


    void Update()
    {



        /*if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);*/
    }

    public void Awake()
    {

        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            //Player hurt
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());


        }else
        {
            //player died
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerController>().enabled = false;
                dead = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(3, 9, true);
        for (int i = 0; i < numOfFlash; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numOfFlash * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numOfFlash * 2));

        }
        //Invunerability duration
        Physics2D.IgnoreLayerCollision(3, 9, false);

    }
}
