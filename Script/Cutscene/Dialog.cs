using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public TextMeshProUGUI nameDisplay;
    public string[] namesentence;
    private int Nindex;
    public float typingSpeed2;

    public GameObject continueButton;
    public GameObject background;
    public GameObject Dialogg;
    public static bool isDialogOn;

    private void Start()
    {
        background.SetActive(true);
        isDialogOn = true;
        StartCoroutine(Type());
        StartCoroutine(Type2());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            //isDialogOn = true;
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
            {
            continueButton.SetActive(false);
            //isDialogOn = true;
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            }
    }

    IEnumerator Type2()
    {
        foreach (char letter in namesentence[Nindex].ToCharArray())
        {
            nameDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed2);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            isDialogOn = true;
            index++;
            Nindex++;
            textDisplay.text = "";
            nameDisplay.text = "";
            StartCoroutine(Type());
            StartCoroutine(Type2());
            //isDialogOn = true;
        }
        else {
            textDisplay.text = "";
            nameDisplay.text = "";
            continueButton.SetActive(false);
            background.SetActive(false);
            isDialogOn = false;
            Dialogg.SetActive(false);
        }
    }
}
