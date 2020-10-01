using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int activeCharacter = 1;
    public GameObject boy;
    public GameObject daughter;
    public GameObject father;
    public GameObject fatherTorch;
    public GameObject daughterTorch;
    public GameObject boyTorch;

    // Start is called before the first frame update
    void Start()
    {
        fatherTorch.GetComponent<SpriteRenderer>().enabled = false;
        daughterTorch.GetComponent<SpriteRenderer>().enabled = false;
        boyTorch.GetComponent<SpriteRenderer>().enabled = false;

        boy.GetComponent<Rigidbody2D>().mass = 0.001f;
        daughter.GetComponent<Rigidbody2D>().mass = 0.001f;
        ActivateFather();
    }

    // AC 1
    void ActivateFather()
    {
        father.GetComponent<Rigidbody2D>().simulated = true;
        boy.GetComponent<Rigidbody2D>().simulated = false;
        daughter.GetComponent<Rigidbody2D>().simulated = false;

        daughter.GetComponent<Animator>().Play("Torchless");
        boy.GetComponent<Animator>().Play("Torchless");
        father.GetComponent<Animator>().Play("Idle");

        fatherTorch.GetComponent<SpriteRenderer>().enabled = true;
        daughterTorch.GetComponent<SpriteRenderer>().enabled = false;
        boyTorch.GetComponent<SpriteRenderer>().enabled = false;
    }

    // AC 2
    void ActivateBoy()
    {
        fatherTorch.GetComponent<SpriteRenderer>().enabled = false;
        daughterTorch.GetComponent<SpriteRenderer>().enabled = false;
        boyTorch.GetComponent<SpriteRenderer>().enabled = true;

        father.GetComponent<Rigidbody2D>().simulated = false;
        boy.GetComponent<Rigidbody2D>().simulated = true;
        daughter.GetComponent<Rigidbody2D>().simulated = false;

        daughter.GetComponent<Animator>().Play("Torchless");
        boy.GetComponent<Animator>().Play("Idle");
        father.GetComponent<Animator>().Play("Torchless");
    }

    // AC 3
    void ActivateDaughter()
    {
        fatherTorch.GetComponent<SpriteRenderer>().enabled = false;
        daughterTorch.GetComponent<SpriteRenderer>().enabled = true;
        boyTorch.GetComponent<SpriteRenderer>().enabled = false;

        father.GetComponent<Rigidbody2D>().simulated = false;
        boy.GetComponent<Rigidbody2D>().simulated = false;
        daughter.GetComponent<Rigidbody2D>().simulated = true;

        daughter.GetComponent<Animator>().Play("Idle");
        boy.GetComponent<Animator>().Play("Torchless");
        father.GetComponent<Animator>().Play("Torchless");
    }




    // Update is called once per frame
    void Update()
    {
        // if character active is touching character not active and presses "e" swap active character to non active
        if (Input.GetKeyDown(KeyCode.E))
        {

            //temp for test
            if (activeCharacter == 1)
            {
                activeCharacter = 2;
                ActivateBoy();
            }
            else if (activeCharacter == 2)
            {
                activeCharacter = 3;
                ActivateDaughter();
            }
            else if (activeCharacter == 3)
            {
                activeCharacter = 1;
                ActivateFather();
            }

            //final with colision check
            ;
        }
    }
}
