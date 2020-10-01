using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class Prologue : MonoBehaviour
{
    public GameObject dialogueBox;
    public float fadeSpeed = 0.01f;

    private Color textColor;
    private bool waning = false;
    private int msgCt = 0;

    // Start is called before the first frame update
    void Start()
    {
        textColor = dialogueBox.GetComponent<Text>().color;     //copy color of dialogue box
        textColor.a = 0;                                        //set alpha to fully transparent
        dialogueBox.GetComponent<Text>().color = textColor;     //set dialogue box to transparent color
        dialogueBox.GetComponent<Text>().text = "\"Wake up...\"";   //set initial text phrase
    }

    // Update is called once per frame
    void Update()
    {
        if (!waning)                            //Waxing (becoming visible)
        {
            textColor.a += fadeSpeed;
            if (textColor.a > 1 - fadeSpeed)
            {
                textColor.a = 1;
                waning = true;
            }
        }
        else if (waning)                        //Waning (becoming invisible)
        {
            textColor.a -= fadeSpeed;
            if (textColor.a < 0 + fadeSpeed)
            {
                textColor.a = 0;
                waning = false;
                msgCt++;
            }
        }
        dialogueBox.GetComponent<Text>().color = textColor;

        switch (msgCt)
        {
            case 1:
                dialogueBox.GetComponent<Text>().text = "My dad's voice.";
                break;
            case 2:
                dialogueBox.GetComponent<Text>().text = "\"Wake up... We need to help your grandma.\"";
                break;
            case 3:
                dialogueBox.GetComponent<Text>().text = "He held a torch in his hand.";
                break;
            case 4:
                dialogueBox.GetComponent<Text>().text = "I didn't know what it was for...";
                break;
            case 5:
                dialogueBox.GetComponent<Text>().text = "...but I knew he'd need me...";
                break;
            case 6:
                dialogueBox.GetComponent<Text>().text = "...and I knew I'd need my little boy.";
                break;
            //case 7:
            //    /*LOAD NEXT SCENE*/
            default:
                msgCt = 0;
                break;
        }

    }
}
