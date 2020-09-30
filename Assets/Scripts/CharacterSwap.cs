using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    public static int activeCharacter = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if character active is touching character not active and presses "e" swap active character to non active
        if(Input.GetKey(KeyCode.E))
        {
            //temp for test
            if (activeCharacter == 1)
            {
                activeCharacter = 2;
            }
            else if (activeCharacter == 2) 
            {
                activeCharacter = 3;
            }
            else if (activeCharacter == 3)
            {
                activeCharacter = 1;
            }

            //final with colision check
            ;
        }
    }
}
