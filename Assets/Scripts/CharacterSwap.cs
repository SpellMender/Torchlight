using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    public static int activeCharacter = 1;


    // Start is called before the first frame update
    void Start()
    {
        ActivateFather();
    }

    // AC 1
    void ActivateFather()
    {
        GameObject.Find("Father").GetComponent<Rigidbody2D>().simulated = true;
        GameObject.Find("Boy").GetComponent<Rigidbody2D>().simulated = false;
        GameObject.Find("Daughter").GetComponent<Rigidbody2D>().simulated = false;
    }

    // AC 2
    void ActivateBoy()
    {
        GameObject.Find("Father").GetComponent<Rigidbody2D>().simulated = false;
        GameObject.Find("Boy").GetComponent<Rigidbody2D>().simulated = true;
        GameObject.Find("Daughter").GetComponent<Rigidbody2D>().simulated = false;
    }

    // AC 3
    void ActivateDaughter()
    {
        GameObject.Find("Father").GetComponent<Rigidbody2D>().simulated = false;
        GameObject.Find("Boy").GetComponent<Rigidbody2D>().simulated = false;
        GameObject.Find("Daughter").GetComponent<Rigidbody2D>().simulated = true;
    }




    // Update is called once per frame
    void Update()
    {
        // if character active is touching character not active and presses "e" swap active character to non active
        if(Input.GetKeyDown(KeyCode.E))
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
