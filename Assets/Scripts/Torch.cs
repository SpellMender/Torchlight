using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject litTorch;
    private bool lit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Torch" && lit == false)
        {
            litTorch.GetComponent<SpriteRenderer>().enabled = true;
            TorchCounter.torchCount += 1;
            lit = true;
        }
    }
}
