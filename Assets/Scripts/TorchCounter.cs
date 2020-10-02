using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchCounter : MonoBehaviour
{
    public static bool unlockDoor = false;
    public static int torchCount;
    public int torchRequirement;
    public int litTorchDebug;

    // Start is called before the first frame update
    void Start()
    {
        torchCount = 0;
        litTorchDebug = 0;
    }

    // Update is called once per frame
    void Update()
    {
        litTorchDebug = torchCount;
        if (torchCount >= torchRequirement)
        {
            unlockDoor = true;
        }
        
    }
}
