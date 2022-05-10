using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health playerHealt;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;


    void Start()
    {
        totalhealthbar.fillAmount = playerHealt.currentHealth / 10;
    }

    
    void Update()
    {
        currenthealthbar.fillAmount = playerHealt.currentHealth / 10;
    }
}
