using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class Epilogue : MonoBehaviour
{
    public float moveSpeed;
    public int waitTime;

    public GameObject father;
    public GameObject boy;
    public GameObject daughter;
    public GameObject daughter_text;
    public GameObject grandmother;
    public GameObject grandma_Text;
    public GameObject heldTorch;
    public GameObject torch;
    public GameObject endText;

    private Rigidbody2D fatherRB;
    private Animator fatherAnim;

    private int sequence = 0;
    private Vector2 motion;
    private bool fatherStop;
    private bool counterOn = false;
    public int counter = 0;

        //for curtain
    public GameObject curtain;
    private Color curtainColor;
    private bool workCurtain;
    private bool waning = false;
    public float fadeSpeed = 0.01f;

        //for curtain text
    //public GameObject curtainText;
    //private Color textColor;
    //private bool workText;


    // Start is called before the first frame update
    void Start()
    {
        fatherRB = father.GetComponent<Rigidbody2D>();

        fatherRB.velocity = new Vector2(moveSpeed, fatherRB.velocity.y);

        fatherAnim = father.GetComponent<Animator>();
        fatherAnim.Play("Walk");


            //for curtain
        curtainColor = curtain.GetComponent<Image>().color;
        //for curtain text
        //textColor = curtainText.GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        //curtains fading
        if(workCurtain)
        {
            if (!waning)                            //Waxing (becoming visible)
            {
                curtainColor.a += fadeSpeed;
                if (curtainColor.a > 1 - fadeSpeed)
                {
                    curtainColor.a = 1;
                    workCurtain = false;
                    counterOn = true;
                }
            }
            else if (waning)                        //Waning (becoming invisible)
            {
                curtainColor.a -= fadeSpeed;
                if (curtainColor.a < 0 + fadeSpeed)
                {
                    curtainColor.a = 0;
                    workCurtain = false;
                    counterOn = true;
                }
            }
            curtain.GetComponent<Image>().color = curtainColor;
        }

        if (fatherStop)
        {
            fatherAnim.Play("Idle");
            fatherRB.velocity = Vector2.zero;
            fatherStop = false;
            sequence = 1;
            counterOn = true;
        }
        if (counterOn)
        {
            counter++;
        }

        //Drop torch
        if (counter >= waitTime && sequence == 1)
        {
            counter = 0;
            sequence = 2;
            //what happens after wait time
            fatherAnim.Play("Torchless");
            heldTorch.SetActive(false);
            torch.SetActive(true);
        }
        if (counter >= waitTime && sequence == 2)
        {
            counter = 0;
            sequence = 3;
            counterOn = false;
            //what happens after wait time
            daughter_text.SetActive(true);
            //curtain fades in
            workCurtain = true;
            waning = false;
        }
        if (counter >= waitTime && sequence == 3)
        {
            counter = 0;
            sequence = 4;
            counterOn = false;
            //what happens after wait time
            daughter_text.SetActive(false);
            grandma_Text.SetActive(true);
            grandmother.SetActive(true);
            father.SetActive(false);
            boy.SetActive(false);
            torch.GetComponent<SpriteRenderer>().enabled = false;
            //curtain fades out
            workCurtain = true;
            waning = true;
        }
        if (counter >= waitTime && sequence == 4)
        {
            counter = 0;
            sequence = 5;
            counterOn = false;
            //what happens after wait time
            grandma_Text.SetActive(false);
            grandmother.SetActive(false);
            //curtain fades out
            curtain.GetComponent<Image>().color = Color.black;
            workCurtain = false;
            endText.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Contains("Player"))
        {
            fatherStop = true;
        }
    }
}
