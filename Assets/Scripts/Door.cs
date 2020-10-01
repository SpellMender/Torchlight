using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool unlocked = false;


    // Update is called once per frame
    void Update()
    {
        if (TorchCounter.unlockDoor == true && unlocked == false) 
        {
            unlocked = true;
            //Now show open the door

        }

        //ADD on collision if door open
        //if(unlocked == true && /*door collision*/ )
        //{ complete scene }


    }
}
